using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CookieFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBatches = int.Parse(Console.ReadLine());
            bool flour = false;
            bool sugar = false;
            bool eggs = false;

            for (int i = 1; i <= numberOfBatches; i++)
            {
                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "Bake!")

                        if (flour == true && eggs == true && sugar == true)
                        {
                            Console.WriteLine($"Baking batch number {i}...");
                            flour = false;
                            eggs = false;
                            sugar = false;
                            break;
                        }

                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                            continue;
                        }

                    switch (command)
                    {
                        case "flour": flour = true; break;
                        case "eggs": eggs = true; break;
                        case "sugar": sugar = true; break;
                    }
                }
            }

        }
    }
}
