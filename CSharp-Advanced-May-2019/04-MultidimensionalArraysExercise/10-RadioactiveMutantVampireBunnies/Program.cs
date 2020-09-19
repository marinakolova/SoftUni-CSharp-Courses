using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] lair = new char[dimensions[0], dimensions[1]];
            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < dimensions[0]; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < dimensions[1]; j++)
                {
                    lair[i, j] = input[j];

                    if (lair[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();

            bool isDead = false;
            bool hasWon = false;

            for (int i = 0; i < commands.Length; i++)
            {
                if (isDead || hasWon)
                {
                    break;
                }

                char command = commands[i];

                switch (command)
                {
                    case 'R':
                        if (IsOutOfTheLair(lair, playerRow, playerCol + 1))
                        {
                            hasWon = true;
                            lair[playerRow, playerCol] = '.';
                        }
                        else if (lair[playerRow, playerCol + 1] == 'B')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerCol += 1;
                            isDead = true;
                        }
                        else if (lair[playerRow, playerCol + 1] == '.')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerCol += 1;
                            lair[playerRow, playerCol] = 'P';
                        }
                        break;

                    case 'L':
                        if (IsOutOfTheLair(lair, playerRow, playerCol - 1))
                        {
                            hasWon = true;
                            lair[playerRow, playerCol] = '.';
                        }
                        else if (lair[playerRow, playerCol - 1] == 'B')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerCol -= 1;
                            isDead = true;
                        }
                        else if (lair[playerRow, playerCol - 1] == '.')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerCol -= 1;
                            lair[playerRow, playerCol] = 'P';
                        }
                        break;

                    case 'U':
                        if (IsOutOfTheLair(lair, playerRow - 1, playerCol))
                        {
                            hasWon = true;
                            lair[playerRow, playerCol] = '.';
                        }
                        else if (lair[playerRow - 1, playerCol] == 'B')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerRow -= 1;
                            isDead = true;
                        }
                        else if (lair[playerRow - 1, playerCol] == '.')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerRow -= 1;
                            lair[playerRow, playerCol] = 'P';
                        }
                        break;

                    case 'D':
                        if (IsOutOfTheLair(lair, playerRow + 1, playerCol))
                        {
                            hasWon = true;
                            lair[playerRow, playerCol] = '.';
                        }
                        else if (lair[playerRow + 1, playerCol] == 'B')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerRow += 1;
                            isDead = true;
                        }
                        else if (lair[playerRow + 1, playerCol] == '.')
                        {
                            lair[playerRow, playerCol] = '.';
                            playerRow += 1;
                            lair[playerRow, playerCol] = 'P';
                        }
                        break;
                }

                List<int> bunniesRows = new List<int>();
                List<int> bunniesCols = new List<int>();

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            bunniesRows.Add(row);
                            bunniesCols.Add(col);
                        }
                    }
                }

                for (int k = 0; k < bunniesRows.Count; k++)
                {
                    int row = bunniesRows[k];
                    int col = bunniesCols[k];

                    if (!IsOutOfTheLair(lair, row + 1, col))
                    {
                        if (lair[row + 1, col] == 'P')
                        {
                            isDead = true;
                        }
                        lair[row + 1, col] = 'B';
                    }
                    if (!IsOutOfTheLair(lair, row - 1, col))
                    {
                        if (lair[row - 1, col] == 'P')
                        {
                            isDead = true;
                        }
                        lair[row - 1, col] = 'B';
                    }
                    if (!IsOutOfTheLair(lair, row, col + 1))
                    {
                        if (lair[row, col + 1] == 'P')
                        {
                            isDead = true;
                        }
                        lair[row, col + 1] = 'B';
                    }
                    if (!IsOutOfTheLair(lair, row, col - 1))
                    {
                        if (lair[row, col - 1] == 'P')
                        {
                            isDead = true;
                        }
                        lair[row, col - 1] = 'B';
                    }
                }
            }

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i,j]);
                }
                Console.WriteLine();
            }
            if (hasWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static bool IsOutOfTheLair(char[,] lair, int checkedRow, int checkedCol)
        {
            return checkedRow < 0 || checkedRow >= lair.GetLength(0)
                || checkedCol < 0 || checkedCol >= lair.GetLength(1);
        }
    }
}
