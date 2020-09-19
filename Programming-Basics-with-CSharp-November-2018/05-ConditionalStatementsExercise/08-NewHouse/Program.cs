using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double rosesPrice = 5;
            double dahliasPrice = 3.80;
            double tulipsPrice = 2.80;
            double narcissusPrice = 3;
            double gladiolusPrice = 2.50;

            double price = 0;

            if (type == "Roses" && count <= 80)
                price = rosesPrice * count;
            else if (type == "Roses" && count > 80)
                price = rosesPrice * count - (0.10 * rosesPrice * count);
            else if (type == "Dahlias" && count <= 90)
                price = dahliasPrice * count;
            else if (type == "Dahlias" && count > 90)
                price = dahliasPrice * count - (0.15 * dahliasPrice * count);
            else if (type == "Tulips" && count <= 80)
                price = tulipsPrice * count;
            else if (type == "Tulips" && count > 80)
                price = tulipsPrice * count - (0.15 * tulipsPrice * count);
            else if (type == "Narcissus" && count < 120)
                price = narcissusPrice * count + (0.15 * narcissusPrice * count);
            else if (type == "Narcissus" && count >= 120)
                price = narcissusPrice * count;
            else if (type == "Gladiolus" && count < 80)
                price = gladiolusPrice * count + (0.20 * gladiolusPrice * count);
            else if (type == "Gladiolus" && count >= 80)
                price = gladiolusPrice * count;

            double moneyLeft = budget - price;
            double moneyNeeded = price - budget;

            if (moneyLeft >= 0)
                Console.WriteLine($"Hey, you have a great garden with {count} {type} and {moneyLeft:F2} leva left.");
            else
                Console.WriteLine($"Not enough money, you need {moneyNeeded:F2} leva more.");
        }
    }
}
