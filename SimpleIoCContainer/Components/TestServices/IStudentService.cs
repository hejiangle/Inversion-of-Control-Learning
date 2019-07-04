using System.Collections.Generic;
using SimpleIoCContainer.Models;

namespace SimpleIoCContainer.Components.TestServices
{
    public interface IStudentService
    {
        IList<Person> GetStudentsByGender(Gender gender);

        IList<Person> GetStudentsAboveScore(int score);

        void RegisterNewStudent(Person student);

        IList<Person> GetAllStudents();
    }
}