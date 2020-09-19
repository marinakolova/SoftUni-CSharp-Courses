using System;
using System.Linq;

namespace _9_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] characters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    field[i, j] = characters[j];
                }
            }

            int startRow = -1;
            int startCol = -1;
            int coalsCount = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (field[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    else if (field[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }

            bool isOver = false;

            for (int i = 0; i < commands.Length; i++)
            {
                if (isOver)
                {
                    break;
                }

                string command = commands[i];
                char currChar = 's';

                switch (command)
                {
                    case "left":

                        if (IsInTheField(field, startRow, startCol - 1))
                        {
                            currChar = field[startRow, startCol - 1];

                            switch (currChar)
                            {
                                case '*':
                                    startCol -= 1;
                                    break;

                                case 's':
                                    startCol -= 1;
                                    break;

                                case 'e':
                                    startCol -= 1;
                                    isOver = true;
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    break;

                                case 'c':
                                    field[startRow, startCol - 1] = '*';
                                    startCol -= 1;
                                    coalsCount--;
                                    if (coalsCount == 0)
                                    {
                                        isOver = true;
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    }
                                    break;
                            }
                        }
                        break;

                    case "right":

                        if (IsInTheField(field, startRow, startCol + 1))
                        {
                            currChar = field[startRow, startCol + 1];

                            switch (currChar)
                            {
                                case '*':
                                    startCol += 1;
                                    break;

                                case 's':
                                    startCol += 1;
                                    break;

                                case 'e':
                                    startCol += 1;
                                    isOver = true;
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    break;

                                case 'c':
                                    field[startRow, startCol + 1] = '*';
                                    startCol += 1;
                                    coalsCount--;
                                    if (coalsCount == 0)
                                    {
                                        isOver = true;
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    }
                                    break;
                            }
                        }
                        break;

                    case "up":

                        if (IsInTheField(field, startRow - 1, startCol))
                        {
                            currChar = field[startRow - 1, startCol];

                            switch (currChar)
                            {
                                case '*':
                                    startRow -= 1;
                                    break;

                                case 's':
                                    startRow -= 1;
                                    break;

                                case 'e':
                                    startRow -= 1;
                                    isOver = true;
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    break;

                                case 'c':
                                    field[startRow - 1, startCol] = '*';
                                    startRow -= 1;
                                    coalsCount--;
                                    if (coalsCount == 0)
                                    {
                                        isOver = true;
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    }
                                    break;
                            }
                        }
                        break;

                    case "down":

                        if (IsInTheField(field, startRow + 1, startCol))
                        {
                            currChar = field[startRow + 1, startCol];

                            switch (currChar)
                            {
                                case '*':
                                    startRow += 1;
                                    break;

                                case 's':
                                    startRow += 1;
                                    break;

                                case 'e':
                                    startRow += 1;
                                    isOver = true;
                                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                                    break;

                                case 'c':
                                    field[startRow + 1, startCol] = '*';
                                    startRow += 1;
                                    coalsCount--;
                                    if (coalsCount == 0)
                                    {
                                        isOver = true;
                                        Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }

            if (!isOver)
            {
                Console.WriteLine($"{coalsCount} coals left. ({startRow}, {startCol})");
            }
        }

        private static bool IsInTheField(char[,] field, int checkedRow, int checkedCol)
        {
            return checkedRow >= 0 && checkedRow < field.GetLength(0)
                && checkedCol >= 0 && checkedCol < field.GetLength(1);
        }
    }
}
