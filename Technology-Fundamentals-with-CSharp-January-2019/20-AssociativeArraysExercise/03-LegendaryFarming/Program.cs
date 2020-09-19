using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, int>();
            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);

            var junk = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine().Split().ToArray();

                for (int i = 0; i < input.Length - 1; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "shards")
                    {
                        materials["shards"] += quantity;

                        if (materials["shards"] >= 250)
                        {
                            break;
                        }
                    }
                    else if (material == "fragments")
                    {
                        materials["fragments"] += quantity;

                        if (materials["fragments"] >= 250)
                        {
                            break;
                        }
                    }
                    else if (material == "motes")
                    {
                        materials["motes"] += quantity;

                        if (materials["motes"] >= 250)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += quantity;
                        }
                        else
                        {
                            junk.Add(material, quantity);
                        }
                    }
                }

                if (materials["shards"] >= 250
                    || materials["fragments"] >= 250
                    || materials["motes"] >= 250)
                {
                    break;
                }
            }

            if (materials["shards"] >= 250)
            {
                materials["shards"] -= 250;
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (materials["fragments"] >= 250)
            {
                materials["fragments"] -= 250;
                Console.WriteLine("Valanyr obtained!");
            }
            else if (materials["motes"] >= 250)
            {
                materials["motes"] -= 250;
                Console.WriteLine("Dragonwrath obtained!");
            }

            var keyMatsToPrint = materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var keyMaterial in keyMatsToPrint)
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }

            var junkMatsToPrint = junk.OrderBy(x => x.Key);

            foreach (var junkMaterial in junkMatsToPrint)
            {
                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
            }
        }
    }
}
