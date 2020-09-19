using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int salaryLeft = salary;

            for (int i = 0; i < n; i++)
            {
                string website = Console.ReadLine();

                switch (website)
                {
                    case "Facebook": salaryLeft = salaryLeft - 150; break;
                    case "Instagram": salaryLeft = salaryLeft - 100; break;
                    case "Reddit": salaryLeft = salaryLeft - 50; break;
                }

                if (salaryLeft <= 0)
                {
                    break;
                }                
            }

            if (salaryLeft <= 0)
                Console.WriteLine("You have lost your salary.");
            else
                Console.WriteLine(salaryLeft);
        }
    }
}
