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
    public static class SimpleIoCContainer
    {
        private static readonly Dictionary<Type, List<Type>> _componentPool = new Dictionary<Type, List<Type>>();

        public static void Register()
        {
            var componentTypes = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                type.GetCustomAttributes(typeof(ComponentAttribute), false).Length > 0);

            foreach (var componentType in componentTypes)
            {
                var interfaceType = componentType.GetInterfaces().First();
                Register(interfaceType, componentType);
            }
        }

        private static void Register(Type interfaceType)
        {
            var uniqueImplementationType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Single(type =>
                    type.IsSubclassOf(interfaceType) || (type == interfaceType && type.IsClass && !type.IsAbstract && !type.IsInterface));
            
            _componentPool.Add(interfaceType, new List<Type>{ uniqueImplementationType });
        }

        public static void Register<TInterface>()
        {
            Register(typeof(TInterface));
        }

        private static void Register(Type interfaceType, Type implementationType)
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

        public static void Register<TInterface, TImplementation>()
        {
            Register(typeof(TInterface), typeof(TImplementation));
        }

        public static void Resolve()
        {
            //TODO: Resolve all dependency by using attributes.
        }

        private static object Resolve(Type interfaceType)
        {
            var defaultImplementationType = _componentPool[interfaceType].First();
            
            return Resolve(interfaceType, defaultImplementationType);
        }

        public static object Resolve<TInterface>()
        {
            return Resolve(typeof(TInterface));
        }

        public static object Resolve<TInterface, TImplementation>()
        {
            return Resolve(typeof(TInterface), typeof(TImplementation));
        }

        private static object Resolve(Type interfaceType, Type implementationType)
        {
            var constructor = implementationType.GetConstructors().First();
            var constructorParameters = constructor.GetParameters();
            
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(implementationType);
            }
    
            var parameters = new List<object>(constructorParameters.Length);
            parameters.AddRange(constructorParameters.Select(parameterInfo => Resolve(parameterInfo.ParameterType)));
            
            return constructor.Invoke(parameters.ToArray());
        }

        public static object ResolveDependant<T>()
        {
            return ResolveDependant(typeof(T));
        }

        private static object ResolveDependant(Type implementationType)
        {
            var fields = implementationType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var hasDependency = fields.Any(field =>
                field.GetCustomAttributes(typeof(DependencyAttribute), false).Length > 0);

            if (!hasDependency)
            {
                return Activator.CreateInstance(implementationType);
            }

            var dependencies = fields.Where(field =>
                field.GetCustomAttributes(typeof(DependencyAttribute), false).Length > 0);

            var dependant = Activator.CreateInstance(implementationType);
            foreach (var dependency in dependencies)
            {
                var dependencyImplementationType = dependency.FieldType;
                if (dependencyImplementationType.IsInterface)
                {
                    dependencyImplementationType = _componentPool[dependency.FieldType].First();
                }

                implementationType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First(field => field.Name.Equals(dependency.Name))
                    .SetValue(dependant,ResolveDependant(dependencyImplementationType));
            }

            return dependant;
        }
    }
}