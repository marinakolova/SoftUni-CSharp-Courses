using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] commands = command.Split().ToArray();

                switch (commands[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(commands[1]);
                        input.Add(numberToAdd);
                        break;

                    case "Insert":
                        int numberToInsert = int.Parse(commands[1]);
                        int indexToInsertAt = int.Parse(commands[2]);
                        if (indexToInsertAt >= 0 && indexToInsertAt < input.Count)
                        {
                            input.Insert(indexToInsertAt, numberToInsert);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    case "Remove":
                        int indexToRemoveAt = int.Parse(commands[1]);
                        if (indexToRemoveAt >= 0 && indexToRemoveAt < input.Count)
                        {
                            input.RemoveAt(indexToRemoveAt);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    case "Shift":
                        string direction = commands[1];
                        int count = int.Parse(commands[2]);
                        switch (direction)
                        {
                            case "left":
                                for (int i = 1; i <= count; i++)
                                {
                                    input.Add(input[0]);
                                    input.RemoveAt(0);
                                }
                                break;

                            case "right":
                                for (int i = 1; i <= count; i++)
                                {
                                    input.Insert(0, input[input.Count - 1]);
                                    input.RemoveAt(input.Count - 1);
                                }
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
