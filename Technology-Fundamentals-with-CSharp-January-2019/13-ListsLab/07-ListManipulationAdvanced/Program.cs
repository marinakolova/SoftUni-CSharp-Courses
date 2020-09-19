using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int changesMade = 0;
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split().ToArray();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        changesMade++;
                        break;

                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        changesMade++;
                        break;

                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemove);
                        changesMade++;
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        changesMade++;
                        break;

                    case "Contains":
                        int numberToCheck = int.Parse(tokens[1]);
                        if (numbers.Contains(numberToCheck))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        List<int> evenNums = numbers.Where(x => x % 2 == 0).ToList();
                        Console.WriteLine(string.Join(" ", evenNums));
                        break;

                    case "PrintOdd":
                        List<int> oddNums = numbers.Where(x => x % 2 != 0).ToList();
                        Console.WriteLine(string.Join(" ", oddNums));
                        break;

                    case "GetSum":
                        int sum = numbers.Sum();
                        Console.WriteLine(sum);
                        break;

                    case "Filter":
                        string condition = tokens[1];
                        int numToCompareWith = int.Parse(tokens[2]);
                        switch (condition)
                        {
                            case "<":
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x < numToCompareWith)));
                                break;

                            case ">":
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x > numToCompareWith)));
                                break;

                            case ">=":
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x >= numToCompareWith)));
                                break;

                            case "<=":
                                Console.WriteLine(string.Join(" ", numbers.Where(x => x <= numToCompareWith)));
                                break;
                        }
                        break;
                }
            }

            if (changesMade > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }            
        }
    }
}
