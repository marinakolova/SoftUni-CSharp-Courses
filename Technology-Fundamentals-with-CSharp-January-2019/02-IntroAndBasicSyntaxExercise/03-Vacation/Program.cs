using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            double pricePerPerson = 0;

            if (type == "Students")
            {
                switch (day)
                {
                    case "Friday": pricePerPerson = 8.45; break;
                    case "Saturday": pricePerPerson = 9.80; break;
                    case "Sunday": pricePerPerson = 10.46; break;
                }
            }

            if (type == "Business")
            {
                switch (day)
                {
                    case "Friday": pricePerPerson = 10.90; break;
                    case "Saturday": pricePerPerson = 15.60; break;
                    case "Sunday": pricePerPerson = 16; break;
                }
            }

            if (type == "Regular")
            {
                switch (day)
                {
                    case "Friday": pricePerPerson = 15; break;
                    case "Saturday": pricePerPerson = 20; break;
                    case "Sunday": pricePerPerson = 22.50; break;
                }
            }

            double totalPrice = people * pricePerPerson;

            if (type == "Students" && people >= 30)
            {
                totalPrice = totalPrice - 0.15 * totalPrice;
            }

            if (type == "Business" && people >= 100)
            {
                totalPrice = totalPrice - 10 * pricePerPerson;
            }

            if (type == "Regular" && people >= 10 && people <= 20)
            {
                totalPrice = totalPrice - 0.05 * totalPrice;
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
