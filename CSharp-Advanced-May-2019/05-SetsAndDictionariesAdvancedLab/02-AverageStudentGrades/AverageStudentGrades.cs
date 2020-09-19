using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var grade = double.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<double>());
                }
                grades[name].Add(grade);
            }

            foreach (var student in grades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(i => i.ToString("F2")))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}
