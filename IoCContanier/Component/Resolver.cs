using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Component
{
    public static class Resolver
    {
        public static T Resolve<T>()
        {
            return Resolve<T, T>();
        }

        public static TContract Resolve<TContract, TImplementation>() {
            return (TContract)Resolve(typeof(TImplementation));
        }

        private static object Resolve(Type implementationType)
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