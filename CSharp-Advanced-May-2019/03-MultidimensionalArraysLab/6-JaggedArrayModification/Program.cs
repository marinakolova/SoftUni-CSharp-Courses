using System;
using System.Linq;

namespace _6_JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = nums;
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var partsOfCommand = command.Split();
                int row = int.Parse(partsOfCommand[1]);
                int col = int.Parse(partsOfCommand[2]);
                int value = int.Parse(partsOfCommand[3]);

                if (row < 0 || row >= rows
                    || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (partsOfCommand[0])
                {
                    case "Add":
                        jaggedArray[row][col] += value;
                        break;

                    case "Subtract":
                        jaggedArray[row][col] -= value;
                        break;
                }
            }

            foreach (var arr in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
