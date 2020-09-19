using System;
using System.Linq;

namespace _10_LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int[] initialField = new int[fieldSize];
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] < initialField.Length
                    && indexes[i] >= 0)
                {
                    initialField[indexes[i]] = 1;
                }
            }

            string input = Console.ReadLine();
            string[] command = new string[3];

            while (input != "end")
            {
                command = input.Split().ToArray();
                int ladyBug = int.Parse(command[0]);
                string direction = command[1];
                int flyLength = int.Parse(command[2]);

                if (ladyBug < initialField.Length
                    && ladyBug >= 0
                    && initialField[ladyBug] == 1
                    && flyLength != 0)
                {
                    if (direction == "right")
                    {
                        if (ladyBug + flyLength < initialField.Length
                            && ladyBug + flyLength >= 0
                            && initialField[ladyBug + flyLength] == 0)
                        {
                            initialField[ladyBug + flyLength] = 1;
                        }
                        else if (ladyBug + flyLength < initialField.Length
                                 && ladyBug + flyLength >= 0
                                 && initialField[ladyBug + flyLength] == 1)
                        {
                            while (ladyBug + flyLength < initialField.Length
                                   && ladyBug + flyLength >= 0
                                   && initialField[ladyBug + flyLength] == 1)
                            {
                                flyLength += flyLength;
                                if (ladyBug + flyLength < initialField.Length
                                    && ladyBug + flyLength >= 0
                                    && initialField[ladyBug + flyLength] == 0)
                                {
                                    initialField[ladyBug + flyLength] = 1;
                                    break;
                                }
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        if (ladyBug - flyLength >= 0
                            && ladyBug - flyLength < initialField.Length
                            && initialField[ladyBug - flyLength] == 0)
                        {
                            initialField[ladyBug - flyLength] = 1;
                        }
                        else if (ladyBug - flyLength >= 0
                                 && ladyBug - flyLength < initialField.Length
                                 && initialField[ladyBug - flyLength] == 1)
                        {
                            while (ladyBug - flyLength >= 0
                                   && ladyBug - flyLength < initialField.Length
                                   && initialField[ladyBug - flyLength] == 1)
                            {
                                flyLength += flyLength;
                                if (ladyBug - flyLength >= 0
                                    && ladyBug - flyLength < initialField.Length
                                    && initialField[ladyBug - flyLength] == 0)
                                {
                                    initialField[ladyBug - flyLength] = 1;
                                    break;
                                }
                            }                            
                        }
                    }

                    initialField[ladyBug] = 0;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", initialField));
        }
    }
}
