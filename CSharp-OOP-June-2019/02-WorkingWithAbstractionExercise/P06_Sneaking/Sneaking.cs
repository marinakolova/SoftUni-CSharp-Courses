using System;

namespace P06_Sneaking
{
    public class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }

            var moves = Console.ReadLine().ToCharArray();

            var samRow = 0;
            var samCol = 0;

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                }
            }

            for (int i = 0; i < moves.Length; i++)
            {
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        if (room[row][col] == 'b')
                        {
                            if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col + 1] = 'b';
                                col++;
                            }
                            else
                            {
                                room[row][col] = 'd';
                            }
                        }
                        else if (room[row][col] == 'd')
                        {
                            if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col - 1] = 'd';
                            }
                            else
                            {
                                room[row][col] = 'b';
                            }
                        }
                    }
                }

                var enemyRow = 0;
                var enemyCol = 0;

                for (int j = 0; j < room[samRow].Length; j++)
                {
                    if (room[samRow][j] != '.' && room[samRow][j] != 'S')
                    {
                        enemyRow = samRow;
                        enemyCol = j;
                    }
                }

                if (samCol < enemyCol && room[enemyRow][enemyCol] == 'd' && enemyRow == samRow)
                {
                    room[samRow][samCol] = 'X';

                    Console.WriteLine($"Sam died at {samRow}, {samCol}");

                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }

                else if (enemyCol < samCol && room[enemyRow][enemyCol] == 'b' && enemyRow == samRow)
                {
                    room[samRow][samCol] = 'X';

                    Console.WriteLine($"Sam died at {samRow}, {samCol}");

                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }

                room[samRow][samCol] = '.';

                switch (moves[i])
                {
                    case 'U':
                        samRow--;
                        break;
                    case 'D':
                        samRow++;
                        break;
                    case 'L':
                        samCol--;
                        break;
                    case 'R':
                        samCol++;
                        break;
                    default:
                        break;
                }

                room[samRow][samCol] = 'S';

                for (int j = 0; j < room[samRow].Length; j++)
                {
                    if (room[samRow][j] != '.' && room[samRow][j] != 'S')
                    {
                        enemyRow = samRow;
                        enemyCol = j;
                    }
                }

                if (room[enemyRow][enemyCol] == 'N' && samRow == enemyRow)
                {
                    room[enemyRow][enemyCol] = 'X';

                    Console.WriteLine("Nikoladze killed!");

                    for (int row = 0; row < room.Length; row++)
                    {
                        for (int col = 0; col < room[row].Length; col++)
                        {
                            Console.Write(room[row][col]);
                        }
                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
            }
        }
    }
}
