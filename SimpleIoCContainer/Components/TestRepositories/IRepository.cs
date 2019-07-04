using System.Collections.Generic;

namespace SimpleIoCContainer.Components.TestRepositories
{
    public interface IRepository<T>
    {
        List<T> ListAll();
        
        void Add(T value);

        void Remove(int id);

        T Find(int id);
    }
}