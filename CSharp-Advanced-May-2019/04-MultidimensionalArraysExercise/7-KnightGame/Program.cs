using System;

namespace _7_KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] board = new char[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    board[row, col] = inputRow[col];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxCount = int.MinValue;
                int conflicts = 0;
                int knightRow = -1;
                int knightCol = -1;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int knightsCount = 0;

                        if (board[row, col] == 'K')
                        {
                            if (IsInside(board, row - 2, col + 1)
                                && board[row - 2, col + 1] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (IsInside(board, row - 2, col - 1)
                                && board[row - 2, col - 1] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (IsInside(board, row + 2, col + 1)
                                && board[row + 2, col + 1] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (IsInside(board, row + 2, col - 1)
                                && board[row + 2, col - 1] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (IsInside(board, row - 1, col - 2)
                                && board[row - 1, col - 2] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (IsInside(board, row - 1, col + 2)
                                && board[row - 1, col + 2] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (IsInside(board, row + 1, col + 2)
                                && board[row + 1, col + 2] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (IsInside(board, row + 1, col - 2)
                                && board[row + 1, col - 2] == 'K')
                            {
                                knightsCount++;
                                conflicts++;
                            }

                            if (knightsCount > maxCount)
                            {
                                maxCount = knightsCount;
                                knightRow = row;
                                knightCol = col;
                            }
                        }                   
                    }
                }

                if (conflicts == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board.GetLength(1) && desiredCol >= 0;
        }
    }
}
