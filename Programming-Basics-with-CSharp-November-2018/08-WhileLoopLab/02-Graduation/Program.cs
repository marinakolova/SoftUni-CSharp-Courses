using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double counter = 1;
            double sum = 0;

            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sum = sum + grade;
                    counter++;
                }                                              
            }

            double average = sum / (counter - 1);
            Console.WriteLine($"{name} graduated. Average grade: {average:F2}");
        }
    }
}
