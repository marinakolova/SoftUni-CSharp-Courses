﻿namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        public Dictionary<string, Student> Repo { get; private set; }

        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);
                if (!Repo.ContainsKey(name))
                {
                    var student = new Student(name, age, grade);
                    Repo[name] = student;
                }
            }
            else if (args[0] == "Show")
            {
                var name = args[1];
                if (Repo.ContainsKey(name))
                {
                    var student = Repo[name];
                    string view = $"{student.Name} is {student.Age} years old.";

                    if (student.Grade >= 5.00)
                    {
                        view += " Excellent student.";
                    }
                    else if (student.Grade < 5.00 && student.Grade >= 3.50)
                    {
                        view += " Average student.";
                    }
                    else
                    {
                        view += " Very nice person.";
                    }

                    Console.WriteLine(view);
                }

            }
            else if (args[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }

    public class Student
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public double Grade { get; private set; }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
    }
}