using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());

            string[] safe = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string item = safe[i];

                long quantity = long.Parse(safe[i + 1]);

                string itemType = string.Empty;

                if (item.Length == 3)
                {
                    itemType = "Cash";
                }
                else if (item.ToLower().EndsWith("gem"))
                {
                    itemType = "Gem";
                }
                else if (item.ToLower() == "gold")
                {
                    itemType = "Gold";
                }

                if (itemType == "")
                {
                    continue;
                }
                else if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":

                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }

                        else if (bag[itemType].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }

                        break;

                    case "Cash":

                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }

                        else if (bag[itemType].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }

                        break;
                }

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, long>();
                }

                if (!bag[itemType].ContainsKey(item))
                {
                    bag[itemType][item] = 0;
                }

                bag[itemType][item] += quantity;

                switch (itemType)
                {
                   case "Gold":
                        gold += quantity;
                        break;

                    case "Gem":
                        gems += quantity;
                        break;

                    case "Cash":
                        cash += quantity;
                        break;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");

                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}