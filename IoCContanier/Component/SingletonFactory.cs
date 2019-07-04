using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.Model;

namespace ClassLibrary1.Component
{
    public class SingletonFactory
    {
        private List<DependencyModel> _dependenciesForSameServerRequest;

        public SingletonFactory()
        {
            Initialize();
        }

        public List<DependencyModel> DependenciesForSameServerRequest => _dependenciesForSameServerRequest;

        public void PopulateDependencies(IEnumerable<DependencyModel> dependencies)
        {
            foreach (var dependencyModel in dependencies.Where(dependency => LifeCircle.SameAsServerRequest.Equals(dependency.LifeCircle)))
            {
                if (dependencyModel.ImplementationInstance == null)
                {
                    dependencyModel.ImplementationInstance = 
                }
            }
            _dependenciesForSameServerRequest.AddRange());
        }

        private void Initialize()
        {
            if (_dependenciesForSameServerRequest == null || _dependenciesForSameServerRequest.Count == 0)
            {
                _dependenciesForSameServerRequest = new List<DependencyModel>();
            }
        }
        
    }
}