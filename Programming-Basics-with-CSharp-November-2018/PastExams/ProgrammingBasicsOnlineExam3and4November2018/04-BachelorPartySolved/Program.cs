using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BachelorPartySolved
{
    class Program
    {
        static void Main(string[] args)
        {
            int singerPrice = int.Parse(Console.ReadLine());

            int guests = 0;

            int income = 0;

            int moneyLeft = 0;


            string command = Console.ReadLine();

            while (!(command == "The restaurant is full"))

            {

                int group = int.Parse(command);

                guests += group;

                if (group < 5)

                    income += group * 100;

                else

                    income += group * 70;


                command = Console.ReadLine();

            }


            moneyLeft = income - singerPrice;


            if (moneyLeft < 0)

                Console.WriteLine($"You have {guests} guests and {income} leva income, but no singer.");

            else

                Console.WriteLine($"You have {guests} guests and {moneyLeft} leva left.");
        }
    }
}
