using System;
using SimpleIoCContainer.Components.TestControllers;

namespace SimpleIoCContainer
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var container = new Utilities.SimpleIoCContainer();
            container.Register();
            container.Register<StudentController>();

            var studentController = (StudentController)container.Resolve(typeof(StudentController));

            var allAbove90ScoresFemaleStudents = studentController.GetAllAbove90ScoresFemaleStudent();

            foreach (var student in allAbove90ScoresFemaleStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}