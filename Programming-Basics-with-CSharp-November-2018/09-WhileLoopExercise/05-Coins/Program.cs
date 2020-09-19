using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double coins = 0;
            change = change * 100;
            
                while (change >= 200)
                {
                    change = change - 200;
                    coins++;
                }

                while (change >= 100)
                {
                    change = change - 100;
                    coins++;
                }

                while (change >= 50)
                {
                    change = change - 50;
                    coins++;
                }

                while (change >= 20)
                {
                    change = change - 20;
                    coins++;
                }

                while (change >= 10)
                {
                    change = change - 10;
                    coins++;
                }

                while (change >= 5)
                {
                    change = change - 5;
                    coins++;
                }

                while (change >= 2)
                {
                    change = change - 2;
                    coins++;
                }

                while (change >= 1)
                {
                    change = change - 1;
                    coins++;
                }
            

            Console.WriteLine(coins);
        }
    }
}
