using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double commission = 0;

            if (town == "Sofia")
            {
                if (sales < 0)
                    Console.WriteLine("error");
                else if (sales >= 0 && sales <= 500)
                {
                    commission = 0.05 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = 0.07 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = 0.08 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 10000)
                {
                    commission = 0.12 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
            }

            else if (town == "Varna")
            {
                if (sales < 0)
                    Console.WriteLine("error");
                else if (sales >= 0 && sales <= 500)
                {
                    commission = 0.045 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = 0.075 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = 0.10 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 10000)
                {
                    commission = 0.13 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
            }

            else if (town == "Plovdiv")
            {
                if (sales < 0)
                    Console.WriteLine("error");
                else if (sales >= 0 && sales <= 500)
                {
                    commission = 0.055 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 500 && sales <= 1000)
                {
                    commission = 0.08 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    commission = 0.12 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
                else if (sales > 10000)
                {
                    commission = 0.145 * sales;
                    Console.WriteLine($"{commission:F2}");
                }
            }

            else
                Console.WriteLine("error");
        }
    }
}
