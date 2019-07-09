using System.Collections.Generic;
using System.Linq;
using SimpleIoCContainer.Attributes;
using SimpleIoCContainer.Components.TestServices;
using SimpleIoCContainer.Models;

namespace SimpleIoCContainer.Components.TestControllers
{
    public class StudentController
    {
        [Dependency]
        private readonly IStudentService _studentService;

//        public StudentController(IStudentService studentService)
//        {
//            _studentService = studentService;
//        }

        public IList<Person> GetAllAbove90ScoresFemaleStudent()
        {
            var above90ScoresStudents = _studentService.GetStudentsAboveScore(90);
            var femaleStudents = _studentService.GetStudentsByGender(Gender.Female);

            return above90ScoresStudents.Intersect(femaleStudents).ToList();
        }
    }
}