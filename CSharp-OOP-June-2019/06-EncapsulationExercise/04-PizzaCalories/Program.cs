using System;

namespace _04_PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            var pizzaInput = Console.ReadLine().Split(" ");
            var doughInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var testPizza = new Pizza(pizzaInput[1], new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3])));
            }            
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                System.Environment.Exit(0);
            }


            var thePizza = new Pizza(pizzaInput[1], new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3])));

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var toppingInput = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var toppingType = toppingInput[1];
                var toppingWeight = double.Parse(toppingInput[2]);

                try
                {
                    var testTopping = new Topping(toppingType, toppingWeight);
                    thePizza.AddTopping(testTopping);
                }
                catch (ArgumentException ex)
                {
                    if (toppingWeight < 1 || toppingWeight > 50)
                    {
                        Console.WriteLine(toppingType + ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                    System.Environment.Exit(0);
                }
            }

            Console.WriteLine(thePizza);
        }
    }
}
