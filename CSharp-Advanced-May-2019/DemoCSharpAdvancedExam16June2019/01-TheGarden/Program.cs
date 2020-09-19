using System;

namespace _01_TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] garden = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                var vegetables = Console.ReadLine().Split();

                var cols = vegetables.Length;

                garden[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    garden[row][col] = vegetables[col];
                }
            }

            var carrots = 0;
            var potatoes = 0;
            var lettuce = 0;
            var harmed = 0;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End of Harvest")
                {
                    break;
                }

                var partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (partsOfCommand[0] == "Harvest")
                {
                    var row = int.Parse(partsOfCommand[1]);
                    var col = int.Parse(partsOfCommand[2]);

                    if (row >= 0 && row < garden.Length
                        && col >= 0 && col < garden[row].Length)
                    {
                        switch (garden[row][col])
                        {
                            case "L":
                                lettuce++;
                                garden[row][col] = " ";
                                break;

                            case "P":
                                potatoes++;
                                garden[row][col] = " ";
                                break;

                            case "C":
                                carrots++;
                                garden[row][col] = " ";
                                break;
                        }                       
                    }
                }

                else if (partsOfCommand[0] == "Mole")
                {
                    var moleRow = int.Parse(partsOfCommand[1]);
                    var moleCol = int.Parse(partsOfCommand[2]);
                    var direction = partsOfCommand[3].ToLower();

                    if (moleRow >= 0 && moleRow < garden.Length
                        && moleCol >= 0 && moleCol < garden[moleRow].Length)
                    {
                        switch (direction)
                        {
                            case "up":

                                for (int row = moleRow; row >= 0; row -= 2)
                                {
                                    if (moleCol < garden[row].Length)
                                    {
                                        if (garden[row][moleCol] != " ")
                                        {
                                            garden[row][moleCol] = " ";
                                            harmed++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "down":

                                for (int row = moleRow; row < garden.Length; row += 2)
                                {
                                    if (moleCol < garden[row].Length)
                                    {
                                        if (garden[row][moleCol] != " ")
                                        {
                                            garden[row][moleCol] = " ";
                                            harmed++;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "left":

                                for (int col = moleCol; col >= 0; col -= 2)
                                {
                                    if (garden[moleRow][col] != " ")
                                    {
                                        garden[moleRow][col] = " ";
                                        harmed++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "right":

                                for (int col = moleCol; col < garden[moleRow].Length; col += 2)
                                {
                                    if (garden[moleRow][col] != " ")
                                    {
                                        garden[moleRow][col] = " ";
                                        harmed++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }
                    }
                }
            }

            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Carrots: {carrots}");
            Console.WriteLine($"Potatoes: {potatoes}");
            Console.WriteLine($"Lettuce: {lettuce}");
            Console.WriteLine($"Harmed vegetables: {harmed}");
        }
    }
}
