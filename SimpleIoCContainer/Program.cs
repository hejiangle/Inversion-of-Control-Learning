using System;
using SimpleIoCContainer.Components.TestControllers;

namespace SimpleIoCContainer
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Utilities.SimpleIoCContainer.Register();
            Utilities.SimpleIoCContainer.Register<StudentController>();

//            var studentController = (StudentController)Utilities.SimpleIoCContainer.Resolve<StudentController>();
            var studentController = (StudentController)Utilities.SimpleIoCContainer.ResolveDependant<StudentController>();

            var allAbove90ScoresFemaleStudents = studentController.GetAllAbove90ScoresFemaleStudent();

            foreach (var student in allAbove90ScoresFemaleStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}