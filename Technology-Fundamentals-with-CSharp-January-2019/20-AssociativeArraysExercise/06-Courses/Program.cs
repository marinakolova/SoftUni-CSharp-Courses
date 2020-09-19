using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfCourses = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] partsOfCommand = command.Split(" : ");
                string courseName = partsOfCommand[0];
                string studentName = partsOfCommand[1];

                if (listOfCourses.ContainsKey(courseName))
                {
                    listOfCourses[courseName].Add(studentName);
                }
                else
                {
                    listOfCourses.Add(courseName, new List<string>());
                    listOfCourses[courseName].Add(studentName);
                }
            }

            foreach (var course in listOfCourses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
