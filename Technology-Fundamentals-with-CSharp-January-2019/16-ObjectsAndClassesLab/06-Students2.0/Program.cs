using System;
using System.Collections.Generic;

namespace _06_Students2._0
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

                string firstName = data[0];
                string lastName = data[1];
                string age = data[2];
                string hometown = data[3];

                if (IsStudentExisting(students, firstName, lastName))
                {
                    Student existingStudent = GetStudent(students, firstName, lastName);

                    existingStudent.Age = age;
                    existingStudent.Hometown = hometown;
                }
                else
                {
                    Student newStudent = new Student();

                    newStudent.FirstName = data[0];
                    newStudent.LastName = data[1];
                    newStudent.Age = data[2];
                    newStudent.Hometown = data[3];

                    students.Add(newStudent);
                }
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

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }

        private static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
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
