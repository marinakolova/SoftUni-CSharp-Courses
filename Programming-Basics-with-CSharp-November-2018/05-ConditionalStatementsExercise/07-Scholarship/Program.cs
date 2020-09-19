using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double success = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = 0.35 * minSalary;
            double successScholarship = success * 25;

            if (success < 4.50)
                Console.WriteLine("You cannot get a scholarship!");

            else if (success == 4.50)
                Console.WriteLine("You cannot get a scholarship!");
                
            else if (success > 4.50)
            {
                if (income >= minSalary && success < 5.50)
                    Console.WriteLine("You cannot get a scholarship!");
                else if (income >= minSalary && success >= 5.50)
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Truncate(successScholarship)} BGN");
                else if (income < minSalary && success < 5.50)
                    Console.WriteLine($"You get a Social scholarship {Math.Truncate(socialScholarship)} BGN");
                else if (income < minSalary && success >= 5.50)
                {
                    if (socialScholarship > successScholarship)
                        Console.WriteLine($"You get a Social scholarship {Math.Truncate(socialScholarship)} BGN");
                    else if (successScholarship >= socialScholarship)
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Truncate(successScholarship)} BGN");
                }
            }                       
        }
    }
}
