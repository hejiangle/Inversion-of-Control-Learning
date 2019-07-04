using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleIoCContainer.Attributes;

namespace SimpleIoCContainer.Utilities
{
    /// <summary>
    /// Simple IoC Container will only include registering and resolving components,
    /// it won't including the lifecycle management,
    /// so that SimpleContainer will create and return new instance each time. 
    /// </summary>
    public class SimpleIoCContainer : IRegister, IResolver
    {
        private readonly Dictionary<Type, List<Type>> _componentPool = new Dictionary<Type, List<Type>>();

        public void Register()
        {
            var componentTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                type.GetCustomAttributes(typeof(ComponentAttribute), false).Length > 0);

            foreach (var componentType in componentTypes)
            {
                var interfaceType = componentType.GetInterfaces().First();
                Register(interfaceType, componentType);
            }
        }

        public void Register(Type interfaceType)
        {
            var uniqueImplementationType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Single(type =>
                    type.IsSubclassOf(interfaceType) || (type == interfaceType && type.IsClass && !type.IsAbstract && !type.IsInterface));
            
            _componentPool.Add(interfaceType, new List<Type>{ uniqueImplementationType });
        }

        public void Register<TInterface>()
        {
            Register(typeof(TInterface));
        }

        public void Register(Type interfaceType, Type implementationType)
        {
            if (_componentPool.ContainsKey(interfaceType))
            {
                _componentPool[interfaceType].Add(implementationType);
            }
            else
            {
                _componentPool.Add(interfaceType, new List<Type>{ implementationType });
            }
        }

        public void Register<TInterface, TImplementation>()
        {
            Register(typeof(TInterface), typeof(TImplementation));
        }

        public void Resolve()
        {
            //TODO: Resolve all dependency by using attributes.
        }

        public object Resolve(Type interfaceType)
        {
            var defaultImplementationType = _componentPool[interfaceType].First();
            
            return Resolve(interfaceType, defaultImplementationType);
        }

        public object Resolve<TInterface>()
        {
            return Resolve(typeof(TInterface));
        }

        public object Resolve<TInterface, TImplementation>()
        {
            return Resolve(typeof(TInterface), typeof(TImplementation));
        }

        public object Resolve(Type interfaceType, Type implementationType)
        {
            var constructor = implementationType.GetConstructors()[0];
            var constructorParameters = constructor.GetParameters();
            
            if (constructorParameters.Length == 0) { 
                return Activator.CreateInstance(implementationType);  
            }
    
            var parameters = new List<object>(constructorParameters.Length);
            parameters.AddRange(constructorParameters.Select(parameterInfo => Resolve(parameterInfo.ParameterType)));
            
            return constructor.Invoke(parameters.ToArray());
        }
    }
}