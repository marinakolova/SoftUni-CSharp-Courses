using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_VaporWinterSale
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").ToList();
            var gamesAndPrices = new Dictionary<string, double>();
            var games = new List<string>();
            var gamesWithDLCs = new Dictionary<string, string>();

            foreach (var item in input)
            {
                if (item.Contains("-"))
                {
                    var partsOfInput = item.Split("-");
                    var gameToAdd = partsOfInput[0];
                    var price = double.Parse(partsOfInput[1]);

                    gamesAndPrices.Add(gameToAdd, price);
                    games.Add(gameToAdd);
                }

                else if (item.Contains(":"))
                {
                    var partsOfInput = item.Split(":");
                    var game = partsOfInput[0];
                    var dlc = partsOfInput[1];

                    if (gamesAndPrices.ContainsKey(game))
                    {
                        gamesWithDLCs.Add(game, dlc);
                        gamesAndPrices[game] += 0.2 * gamesAndPrices[game];
                    }
                }
            }

            foreach (var game in games)
            {
                if (!gamesWithDLCs.ContainsKey(game))
                {
                    gamesAndPrices[game] -= 0.2 * gamesAndPrices[game];
                }
                else if (gamesWithDLCs.ContainsKey(game))
                {
                    gamesAndPrices[game] -= 0.5 * gamesAndPrices[game];
                }
            }

            foreach (var game in gamesAndPrices.Where(x => gamesWithDLCs.ContainsKey(x.Key)).OrderBy(x => x.Value))
            {
                Console.WriteLine($"{game.Key} - {gamesWithDLCs[game.Key]} - {game.Value:F2}");
            }
            foreach (var game in gamesAndPrices.Where(x => !gamesWithDLCs.ContainsKey(x.Key)).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{game.Key} - {game.Value:F2}");
            }
        }
    }
}
