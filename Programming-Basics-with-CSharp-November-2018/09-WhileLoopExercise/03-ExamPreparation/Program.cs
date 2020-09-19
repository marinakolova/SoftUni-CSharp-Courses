using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGradesCount = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int poorGrades = 0;
            string lastProblem = "";
            int problemsCount = 0;
            double gradesSum = 0;

            while (command != "Enough" && poorGrades < poorGradesCount)
            {
                string problemName = command;
                double grade = double.Parse(Console.ReadLine());
                gradesSum += grade;
                problemsCount++;
                lastProblem = problemName;

                if (grade <= 4.00)
                {
                    poorGrades++;
                }

                if (poorGrades >= poorGradesCount)
                {
                    break;
                }

                command = Console.ReadLine();
            }


            double averageGrade = gradesSum / problemsCount;

            if (poorGrades >= poorGradesCount)
            {
                Console.WriteLine($"You need a break, {poorGrades} poor grades.");
            }

            else
            {
                Console.WriteLine($"Average score: {averageGrade:F2}");
                Console.WriteLine($"Number of problems: {problemsCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
