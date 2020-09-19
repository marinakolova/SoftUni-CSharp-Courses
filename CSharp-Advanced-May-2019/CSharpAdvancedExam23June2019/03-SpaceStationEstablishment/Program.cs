using System;

namespace _03_SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var galaxy = new char[n][];

            for (int row = 0; row < n; row++)
            {
                galaxy[row] = new char[n];
                galaxy[row] = Console.ReadLine().ToCharArray();
            }

            var shipRow = -1;
            var shipCol = -1;

            var blackHoleOneRow = -1;
            var blackHoleOneCol = -1;

            var blackHoleTwoRow = -1;
            var blackHoleTwoCol = -1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (galaxy[row][col] == 'S')
                    {
                        shipRow = row;
                        shipCol = col;
                    }

                    else if (galaxy[row][col] == 'O')
                    {
                        if (blackHoleOneRow == -1)
                        {
                            blackHoleOneRow = row;
                            blackHoleOneCol = col;
                        }
                        else
                        {
                            blackHoleTwoRow = row;
                            blackHoleTwoCol = col;
                        }
                    }
                }
            }

            var starPower = 0;

            while (starPower < 50)
            {
                var command = Console.ReadLine();
                galaxy[shipRow][shipCol] = '-';

                switch (command)
                {
                    case "up":
                        shipRow--;
                        break;

                    case "down":
                        shipRow++;
                        break;

                    case "left":
                        shipCol--;
                        break;

                    case "right":
                        shipCol++;
                        break;
                }

                if (isInGalaxy(shipRow, shipCol, n))
                {
                    var symbolEncountered = galaxy[shipRow][shipCol];

                    if (symbolEncountered == 'O')
                    {
                        if (shipRow == blackHoleOneRow && shipCol == blackHoleOneCol)
                        {
                            shipRow = blackHoleTwoRow;
                            shipCol = blackHoleTwoCol;

                            galaxy[blackHoleOneRow][blackHoleOneCol] = '-';
                            galaxy[blackHoleTwoRow][blackHoleTwoCol] = 'S';
                        }
                        else
                        {
                            shipRow = blackHoleOneRow;
                            shipCol = blackHoleOneCol;

                            galaxy[blackHoleTwoRow][blackHoleTwoCol] = '-';
                            galaxy[blackHoleOneRow][blackHoleOneCol] = 'S';
                        }
                    }

                    else if(char.IsDigit(symbolEncountered))
                    {
                        var starPowerToCollect = int.Parse(symbolEncountered.ToString());
                        starPower += starPowerToCollect;
                        galaxy[shipRow][shipCol] = 'S';
                    }
                }

                else
                {
                    break;
                }
            }

            if (starPower < 50)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {starPower}");

            foreach (var row in galaxy)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static bool isInGalaxy(int shipRow, int shipCol, int galaxySize)
        {
            if (shipRow >= 0 && shipRow < galaxySize
                && shipCol >= 0 && shipCol < galaxySize)
            {
                return true;
            }

            return false;
        }
    }
}
