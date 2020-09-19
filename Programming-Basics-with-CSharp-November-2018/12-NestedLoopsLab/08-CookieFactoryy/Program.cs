using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CookieFactoryy
{
    class Program
    {
        static void Main(string[] args)
        {
            int batchesNeeded = int.Parse(Console.ReadLine());
            int successfulBatches = 0;
            int flour = 0;
            int eggs = 0;
            int sugar = 0;

            while (successfulBatches < batchesNeeded)
            {
                string ingredient = Console.ReadLine();

                switch (ingredient)
                {
                    case "flour": flour++; break;
                    case "eggs": eggs++; break;
                    case "sugar": sugar++; break;
                    case "Bake!":
                        if (flour > 0 && eggs > 0 && sugar > 0)
                        {
                            successfulBatches++;
                            Console.WriteLine($"Baking batch number {successfulBatches}...");
                            flour = 0;
                            eggs = 0;
                            sugar = 0;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }
                        break;
                }
            }
        }
    }
}
