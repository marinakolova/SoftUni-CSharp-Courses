using System;
using System.Linq;

namespace _11_ArrayManipulator3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input.Split();

                if (command[0] == "exchange")
                {
                    int positionToExchange = int.Parse(command[1]);

                    if (positionToExchange >= 0 && positionToExchange < array.Length)
                    {

                        Exchange(array, positionToExchange);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                }

                else if (command[0] == "max")
                {
                    string typeNum = command[1];
                    int index = -1;

                    if (typeNum == "odd")
                    {
                        index = MaxEvenOrOddIndex(array, 1);
                        Console.WriteLine(index);
                    }
                    else
                    {
                        index = MaxEvenOrOddIndex(array, 0);
                        Console.WriteLine(index);
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }
                }

                else if (command[0] == "min")
                {
                    string typeNum = command[1];
                    int index = -1;

                    if (typeNum == "odd")
                    {
                        index = MinEvenOrOddIndex(array, 1);

                    }
                    else
                    {
                        index = MinEvenOrOddIndex(array, 0);

                    }
                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }
                    Console.WriteLine(index);
                }

                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    string typeNum = command[2];
                    int[] result = new int[0];

                    if (typeNum == "odd")
                    {
                        result = FirstEvenOrOddElements(array, count, 1);
                    }
                    else if (typeNum == "even")
                    {
                        result = FirstEvenOrOddElements(array, count, 0);
                    }

                    Console.WriteLine("[" + string.Join(", ", result) + "]");
                }

                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);

                    if (count > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    string typeNum = command[2];
                    int[] result = new int[0];

                    if (typeNum == "odd")
                    {
                        result = LastEvenOrOddElements(array, count, 1);
                    }
                    else if (typeNum == "even")
                    {
                        result = LastEvenOrOddElements(array, count, 0);
                    }

                    Console.WriteLine("[" + string.Join(", ", result) + "]");
                }

            }

            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        private static int[] LastEvenOrOddElements(int[] arr, int neededCount, int divisibleResult)
        {
            int[] resultArr = new int[neededCount];
            int currCounter = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] % 2 == divisibleResult && currCounter < neededCount)
                {
                    resultArr[currCounter] = arr[i];
                    currCounter++;
                }
            }

            if (currCounter >= neededCount)
            {
                return resultArr.Reverse().ToArray();
            }
            else
            {
                int[] tempArr = new int[currCounter];
                Array.Copy(resultArr, tempArr, currCounter);
                return tempArr.Reverse().ToArray();
            }
        }

        public static void Exchange(int[] arr, int position)
        {
            for (int i = 0; i <= position; i++)
            {
                int firstNum = arr[0];

                for (int j = 0; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }

                arr[arr.Length - 1] = firstNum;
            }

        }

        public static int MaxEvenOrOddIndex(int[] arr, int divisonResult)
        {
            int maxNum = int.MinValue;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= maxNum && arr[i] % 2 == divisonResult)
                {
                    maxNum = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static int MinEvenOrOddIndex(int[] arr, int divisonResult)
        {
            int minNum = int.MaxValue;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= minNum && arr[i] % 2 == divisonResult)
                {
                    minNum = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static int[] FirstEvenOrOddElements(int[] arr, int neededCount, int divisibleResult)
        {
            int[] resultArr = new int[neededCount];
            int currCounter = 0;


            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == divisibleResult && currCounter < neededCount)
                {
                    resultArr[currCounter] = arr[i];
                    currCounter++;
                }
            }

            if (currCounter >= neededCount)
            {
                return resultArr;
            }
            else
            {
                int[] tempArr = new int[currCounter];
                Array.Copy(resultArr, tempArr, currCounter);
                return tempArr;
            }
        }
    }
}