using System;

namespace SimpleIoCContainer.Utilities
{
    public interface IRegister
    {
        /// <summary>
        /// This method will register all classes, which is marked with [Component].
        /// </summary>
        void Register();
        
        /// <summary>
        /// Non-generic method for registering a single implementation type interface.
        /// </summary>
        /// <param name="interfaceType">The type of interface</param>
        void Register(Type interfaceType);
        
        /// <summary>
        /// Register the interface with single implementation type. 
        /// </summary>
        /// <typeparam name="TInterface">
        /// The type of interface which you want to register into container.
        /// </typeparam>
        void Register<TInterface>();

        void Register(Type interfaceType, Type implementationType);
        
        /// <summary>
        /// Register the interface with specific implementation type.
        /// This method would be used for the interface which has multiple implementation types.
        /// </summary>
        /// <typeparam name="TInterface">The type of interface.</typeparam>
        /// <typeparam name="TImplementation">The type of implementation.</typeparam>
        void Register<TInterface, TImplementation>();
    }
}