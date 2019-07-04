using System.Collections.Generic;
using SimpleIoCContainer.Attributes;
using SimpleIoCContainer.Models;

namespace SimpleIoCContainer.Components.TestRepositories
{
    [Component]
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _students = new List<Person>
        {
            new Person(1, "Oliver Queen", 30, Gender.Male, 90),
            new Person(2, "Arya Stack", 18, Gender.Female, 95)
        };

        public List<Person> ListAll()
        {
            return _students;
        }

        public void Add(Person student)
        {
            if (!_students.Exists(s => student.Id.Equals(s.Id)))
            {
                _students.Add(student);
            }
        }

        public void Remove(int id)
        {
            if (_students.Exists(s => id.Equals(s.Id)))
            {
                var student = _students.Find(s => id.Equals(s.Id));
                _students.Remove(student);
            }
        }

        public Person Find(int id)
        {
            return _students.Find(s => id.Equals(s.Id));
        }
    }
}