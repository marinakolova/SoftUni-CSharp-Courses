using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "3:1")
                {
                    break;
                }

                string[] partsOfTheCommand = command.Split().ToArray();

                switch (partsOfTheCommand[0])
                {
                    case "merge":

                        int startIndex = int.Parse(partsOfTheCommand[1]);
                        int endIndex = int.Parse(partsOfTheCommand[2]);

                        if (startIndex < 0 && endIndex < input.Count)
                        {
                            for (int i = 1; i <= endIndex; i++)
                            {
                                input[0] += input[1];
                                input.RemoveAt(1);
                            }
                        }
                        else if (startIndex < 0 && endIndex >= input.Count)
                        {
                            int inputCount = input.Count;
                            for (int i = 1; i < inputCount; i++)
                            {
                                input[0] += input[1];
                                input.RemoveAt(1);
                            }
                        }
                        else if (startIndex >= 0 && endIndex < input.Count)
                        {
                            for (int i = startIndex + 1; i <= endIndex; i++)
                            {
                                input[startIndex] += input[startIndex + 1];
                                input.RemoveAt(startIndex + 1);
                            }
                        }
                        else if (startIndex >= 0 && endIndex >= input.Count)
                        {
                            int inputCount = input.Count;
                            for (int i = startIndex + 1; i < inputCount; i++)
                            {
                                input[startIndex] += input[startIndex + 1];
                                input.RemoveAt(startIndex + 1);
                            }
                        }

                        break;

                    case "divide":

                        int index = int.Parse(partsOfTheCommand[1]);
                        int partitions = int.Parse(partsOfTheCommand[2]);
                        if (partitions > 1)
                        {
                            List<string> dividedElements = Divide(input, index, partitions);
                            input.RemoveAt(index);
                            input.InsertRange(index, dividedElements);
                        }
                        
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }

        private static List<string> Divide(List<string> input, int index, int partitions)
        {
            string elementToDivide = input[index];
            string dividedElement = "";

            if (elementToDivide.Length % partitions == 0)
            {
                int lengthOfPartitions = elementToDivide.Length / partitions;
                for (int i = 0; i < partitions; i++)
                {
                    dividedElement += elementToDivide.Substring(0, lengthOfPartitions);
                    dividedElement += " ";
                    elementToDivide = elementToDivide.Remove(0, lengthOfPartitions);
                }
            }
            else
            {
                int lengthOfPartitions = elementToDivide.Length / partitions;
                int lengthOfLastPartition = lengthOfPartitions + (elementToDivide.Length % partitions);
                for (int i = 0; i < partitions - 1; i++)
                {
                    dividedElement += elementToDivide.Substring(0, lengthOfPartitions);
                    dividedElement += " ";
                    elementToDivide = elementToDivide.Remove(0, lengthOfPartitions);
                }
                dividedElement += elementToDivide;
            }

            List<string> dividedElements = dividedElement.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            return dividedElements;
        }
    }
}
