using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_GraduationPartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double counter = 1;
            double sum = 0;
            double repeats = 0;
            bool excluded = false;

            while (counter <= 12 && excluded == false)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sum = sum + grade;
                    counter++;
                }
                else if (grade < 4.00)
                {
                    repeats++;
                    if (repeats >= 2)
                        excluded = true;
                }                
            }

            double average = sum / (counter - 1);

            if (counter == 13)
                Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
            else if (counter < 13)
                Console.WriteLine($"{name} has been excluded at {counter} grade");
        }
    }
}
