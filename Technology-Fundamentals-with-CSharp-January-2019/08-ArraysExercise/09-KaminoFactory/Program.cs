using System;
using System.Linq;

namespace _09_KaminoFactory // 50/100 all mine
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequencesLength = int.Parse(Console.ReadLine());
            string[] sequence = new string[sequencesLength];
            string input = Console.ReadLine();

            int sequenceIndex = 0;
            int bestSequenceIndex = 0;

            int sequenceOfOnes = 0;
            int maxSequenceOfOnes = 0;
            int maxSequenceOfOnesIndex = sequence.Length + 2;

            int maxSequenceOfOnesAll = 0;
            int maxSequenceOfOnesIndexAll = sequence.Length + 2;

            int sequenceSum = 0;
            int bestSequenceSum = 0;
                       

            string[] bestSequence = new string[sequencesLength];

            while (input != "Clone them!")
            {
                sequence = input.Split('!').ToArray();
                sequenceIndex++;

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == "1")
                    {
                        sequenceSum++;
                        sequenceOfOnes++;

                        if (sequenceOfOnes > maxSequenceOfOnes)
                        {
                            maxSequenceOfOnes = sequenceOfOnes;
                            maxSequenceOfOnesIndex = i - sequenceOfOnes;
                        }
                    }

                    else if ((sequence[i] == "0"))
                    {
                        sequenceOfOnes = 0;
                    }                    
                }

                if (maxSequenceOfOnes > maxSequenceOfOnesAll)
                {
                    maxSequenceOfOnesAll = maxSequenceOfOnes;
                    maxSequenceOfOnesIndexAll = maxSequenceOfOnesIndex;
                    bestSequence = sequence;
                    bestSequenceIndex = sequenceIndex;
                    bestSequenceSum = sequenceSum;
                }

                else if (maxSequenceOfOnes == maxSequenceOfOnesAll)
                {
                    if (maxSequenceOfOnesIndex < maxSequenceOfOnesIndexAll)
                    {
                        maxSequenceOfOnesIndexAll = maxSequenceOfOnesIndex;
                        bestSequence = sequence;
                        bestSequenceIndex = sequenceIndex;
                        bestSequenceSum = sequenceSum;
                    }

                    else if (maxSequenceOfOnesIndex == maxSequenceOfOnesIndexAll)
                    {
                        if (sequenceSum > bestSequenceSum)
                        {
                            bestSequence = sequence;
                            bestSequenceIndex = sequenceIndex;
                            bestSequenceSum = sequenceSum;
                        }
                    }
                }

                sequenceOfOnes = 0;
                maxSequenceOfOnes = 0;
                maxSequenceOfOnesIndex = sequence.Length + 2;
                sequenceSum = 0;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");

            foreach (var num in bestSequence)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
