using System.Collections.Generic;
using System.Linq;
using SimpleIoCContainer.Attributes;
using SimpleIoCContainer.Components.TestRepositories;
using SimpleIoCContainer.Models;

namespace SimpleIoCContainer.Components.TestServices
{
    [Component]
    public class StudentService : IStudentService
    {
        private readonly IPersonRepository _personRepository;

        public StudentService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IList<Person> GetStudentsByGender(Gender gender)
        {
            return _personRepository
                .ListAll()
                .Where(student => gender.Equals(student.Gender))
                .ToList();
        }

        public IList<Person> GetStudentsAboveScore(int score)
        {
            return _personRepository
                .ListAll()
                .Where(student => score < student.Scores)
                .ToList();
        }

        public void RegisterNewStudent(Person student)
        {
            if (_personRepository.Find(student.Id) == null)
            {
                _personRepository.Add(student);
            }
        }

        public IList<Person> GetAllStudents()
        {
            return _personRepository.ListAll();
        }
    }
}