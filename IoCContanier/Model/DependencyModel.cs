using System;

namespace ClassLibrary1.Model
{
    public class DependencyModel
    {
        public Type InterfaceType { get; }

        public Type ImplementationType { get; }

        public object ImplementationInstance { get; private set; }

        public LifeCircle LifeCircle { get; }

        public DependencyModel(Type interfaceType, Type implementationType, object implementationInstance,
            LifeCircle lifeCircle)
        {
            InterfaceType = interfaceType;
            ImplementationType = implementationType;
            ImplementationInstance = implementationInstance;
            LifeCircle = lifeCircle;
        }

        public DependencyModel(Type interfaceType, Type implementationType, LifeCircle lifeCircle)
        {
            InterfaceType = interfaceType;
            ImplementationType = implementationType;
            LifeCircle = lifeCircle;
        }

        public DependencyModel(Type interfaceType, object implementationInstance) : this(interfaceType, interfaceType,
            implementationInstance, LifeCircle.SameAsApplication)
        {
            ImplementationType = interfaceType;
            ImplementationInstance = implementationInstance;
        }

    }
}