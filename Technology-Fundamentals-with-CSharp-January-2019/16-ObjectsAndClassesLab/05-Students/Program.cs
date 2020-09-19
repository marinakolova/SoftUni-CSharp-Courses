using System;
using System.Collections.Generic;

namespace _05_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] data = input.Split();

                Student newStudent = new Student();

                newStudent.FirstName = data[0];
                newStudent.LastName = data[1];
                newStudent.Age = data[2];
                newStudent.Hometown = data[3];

                students.Add(newStudent);
            }

            string city = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.Hometown == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }
    }
}
