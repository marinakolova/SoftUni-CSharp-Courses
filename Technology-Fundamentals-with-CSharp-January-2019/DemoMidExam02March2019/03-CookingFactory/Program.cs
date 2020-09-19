using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> batches = new List<int[]>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Bake It!")
                {
                    break;
                }

                int[] newBatch = input.Split("#").Select(int.Parse).ToArray();

                batches.Add(newBatch);
            }

            int bestTotalQuality = int.MinValue;
            double bestAvgQuality = double.MinValue;
            int bestFewEl = int.MaxValue;
            int[] bestBatch = new int[10];

            for (int i = 0; i < batches.Count; i++)
            {
                int currTotalQuality = 0;
                double currAvgQuality = 0;
                int currEl = 0;

                for (int j = 0; j < batches[i].Length; j++)
                {
                    currTotalQuality += batches[i][j];
                }

                currAvgQuality = currTotalQuality / batches[i].Length;
                currEl = batches[i].Length;

                if (currTotalQuality > bestTotalQuality)
                {
                    bestTotalQuality = currTotalQuality;
                    bestAvgQuality = currAvgQuality;
                    bestFewEl = currEl;
                    bestBatch = batches[i];
                }

                else if (currTotalQuality == bestTotalQuality)
                {
                    if (currAvgQuality > bestAvgQuality)
                    {
                        bestAvgQuality = currAvgQuality;
                        bestFewEl = currEl;
                        bestBatch = batches[i];
                    }

                    else if (currAvgQuality == bestAvgQuality)
                    {
                        if (currEl < bestFewEl)
                        {
                            bestFewEl = currEl;
                            bestBatch = batches[i];
                        }
                    }
                }
            }

            Console.WriteLine($"Best Batch quality: {bestTotalQuality}");
            Console.WriteLine(string.Join(" ", bestBatch));
        }
    }
}
