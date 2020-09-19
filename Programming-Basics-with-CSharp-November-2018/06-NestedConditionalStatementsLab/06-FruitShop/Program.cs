using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double price = 0;

            if (fruit == "banana")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 2.50 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 2.70 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else
                    Console.WriteLine("error");
            }

            else if (fruit == "apple")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 1.20 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 1.25 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else
                    Console.WriteLine("error");
            }

            else if (fruit == "orange")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 0.85 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 0.90 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else
                    Console.WriteLine("error");
            }

            else if (fruit == "grapefruit")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 1.45 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 1.60 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else
                    Console.WriteLine("error");
            }

            else if (fruit == "kiwi")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 2.70 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 3.00 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else
                    Console.WriteLine("error");
            }

            else if (fruit == "pineapple")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 5.50 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 5.60 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else
                    Console.WriteLine("error");
            }

            else if (fruit == "grapes")
            {
                if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
                {
                    price = 3.85 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else if (day == "Saturday" || day == "Sunday")
                {
                    price = 4.20 * count;
                    Console.WriteLine(Math.Round(price, 2));
                }
                else
                    Console.WriteLine("error");
            }

            else
                Console.WriteLine("error");
        }
    }
}
