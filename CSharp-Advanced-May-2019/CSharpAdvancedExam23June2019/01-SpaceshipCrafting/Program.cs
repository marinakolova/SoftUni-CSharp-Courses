using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var liquidsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var itemsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var liquids = new Queue<int>(liquidsInput);
            var items = new Stack<int>(itemsInput);

            var neededMaterials = new Dictionary<int, string>();
            neededMaterials.Add(25, "Glass");
            neededMaterials.Add(50, "Aluminium");
            neededMaterials.Add(75, "Lithium");
            neededMaterials.Add(100, "Carbon fiber");

            var craftedMaterials = new Dictionary<string, int>();
            craftedMaterials.Add("Glass", 0);
            craftedMaterials.Add("Aluminium", 0);
            craftedMaterials.Add("Lithium", 0);
            craftedMaterials.Add("Carbon fiber", 0);

            while (liquids.Count > 0 && items.Count > 0)
            {
                var liquidToCombine = liquids.Dequeue();
                var itemToCombine = items.Pop();

                var sum = liquidToCombine + itemToCombine;

                if (neededMaterials.ContainsKey(sum))
                {
                    craftedMaterials[neededMaterials[sum]] += 1;
                }

                else
                {
                    itemToCombine += 3;
                    items.Push(itemToCombine);
                }
            }

            if (craftedMaterials["Glass"] > 0
                && craftedMaterials["Aluminium"] > 0
                && craftedMaterials["Lithium"] > 0
                && craftedMaterials["Carbon fiber"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (items.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var material in craftedMaterials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
