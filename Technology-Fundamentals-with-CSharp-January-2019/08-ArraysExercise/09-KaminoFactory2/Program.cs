using System;
using System.Linq;

namespace _09_KaminoFactory2 // second mine try - failure
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequencesLength = int.Parse(Console.ReadLine());
            string[] sequence = new string[sequencesLength];
            int[] DNA = new int[sequencesLength];
            int sequenceIndex = 0;
            int bestDNAIndex = 0;

            int sum = 0;
            int maxSum = 0;
            int ones = 0;
            int maxOnesInSeq = 0;
            int maxOnesAll = 0;
            int indexOfMaxOnesInSeq = -5;
            int indexOfMaxOnesAll = -5;

            int[] bestDNA = new int[sequencesLength];

            string input = Console.ReadLine();
            while (input != "Clone them!")
            {
                sequence = input.Split('!').ToArray();
                for (int i = 0; i < sequencesLength; i++)
                {
                    DNA[i] = int.Parse(sequence[i]);
                }
                sequenceIndex++;

                for (int j = 0; j < sequencesLength; j++)
                {
                    sum += DNA[j];

                    if (DNA[j] == 1)
                    {
                        ones++;

                        if (ones > maxOnesInSeq)
                        {
                            maxOnesInSeq = ones;
                            indexOfMaxOnesInSeq = j - ones;
                        }
                    }
                    else
                    {
                        ones = 0;
                    }
                }

                if (maxOnesInSeq > maxOnesAll)
                {
                    maxOnesAll = maxOnesInSeq;
                    indexOfMaxOnesAll = indexOfMaxOnesInSeq;
                    maxSum = sum;
                    bestDNA = DNA;
                    bestDNAIndex = sequenceIndex;
                }
                else if (maxOnesInSeq == maxOnesAll)
                {
                    if (indexOfMaxOnesInSeq < indexOfMaxOnesAll)
                    {
                        maxOnesAll = indexOfMaxOnesInSeq;
                        maxSum = sum;
                        bestDNA = DNA;
                        bestDNAIndex = sequenceIndex;
                    }
                    else if (indexOfMaxOnesAll == indexOfMaxOnesInSeq)
                    {
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            bestDNA = DNA;
                            bestDNAIndex = sequenceIndex;
                        }
                    }
                }

                sum = 0;
                ones = 0;
                maxOnesInSeq = 0;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestDNAIndex} with sum: {maxSum}.");

            foreach (var num in bestDNA)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

        }
    }
}
