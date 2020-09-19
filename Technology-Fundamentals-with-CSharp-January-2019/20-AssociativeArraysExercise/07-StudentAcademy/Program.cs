using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var listOfStudents = new Dictionary<string, List<double>>();

            for (int i = 1; i <= n * 2 - 1; i += 2)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (listOfStudents.ContainsKey(studentName))
                {
                    listOfStudents[studentName].Add(grade);
                }
                else
                {
                    listOfStudents.Add(studentName, new List<double>());
                    listOfStudents[studentName].Add(grade);
                }
            }

            foreach (var student in listOfStudents.Where(x => x.Value.Average() >= 4.50).OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
            }
        }
    }
}
