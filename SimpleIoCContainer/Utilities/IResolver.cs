using System;

namespace SimpleIoCContainer.Utilities
{
    public interface IResolver
    {
        void Resolve();
        
        /// <summary>
        /// Resolve the specific interface to create the default implementation instance.
        /// </summary>
        /// <param name="interfaceType">
        ///     The type of specific interface.
        /// </param>
        object Resolve(Type interfaceType);

        object Resolve<TInterface>();
        
        /// <summary>
        /// Resolve the specific implementation type of specific interface to create instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of interface.</typeparam>
        /// <typeparam name="TImplementation">The type of implementation.</typeparam>
        object Resolve<TInterface, TImplementation>();

        object Resolve(Type interfaceType, Type implementationType);

        /// <summary>
        /// Resolve the specific Dependant by using the first implementation.
        /// </summary>
        /// <typeparam name="T">
        /// The type of Dependant.
        /// </typeparam>
        object ResolveDependant<T>();
    }
}