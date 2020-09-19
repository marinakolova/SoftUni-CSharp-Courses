using System;
using System.Linq;

namespace _11_ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] manipulationCommands = command.Split().ToArray();

                if (manipulationCommands[0] == "exchange")
                {
                    int index = int.Parse(manipulationCommands[1]);

                    if (index < 0 || index > initialArray.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        initialArray = Exchange(initialArray, index);
                    }
                }

                else if (manipulationCommands[0] == "max")
                {
                    if (manipulationCommands[1] == "even")
                    {
                        int maxEvenIndex = GetMaxEven(initialArray);
                        if (maxEvenIndex != -1)
                        {
                            Console.WriteLine(maxEvenIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }

                    else if (manipulationCommands[1] == "odd")
                    {
                        int maxOddIndex = GetMaxOdd(initialArray);
                        if (maxOddIndex != -1)
                        {
                            Console.WriteLine(maxOddIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                }

                else if (manipulationCommands[0] == "min")
                {
                    if (manipulationCommands[1] == "even")
                    {
                        int minEvenIndex = GetMinEven(initialArray);
                        if (minEvenIndex != -1)
                        {
                            Console.WriteLine(minEvenIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }

                    else if (manipulationCommands[1] == "odd")
                    {
                        int minOddIndex = GetMinOdd(initialArray);
                        if (minOddIndex != -1)
                        {
                            Console.WriteLine(minOddIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                }

                else if (manipulationCommands[0] == "first")
                {
                    int count = int.Parse(manipulationCommands[1]);

                    if (count > initialArray.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }

                    else
                    {
                        if (manipulationCommands[2] == "even")
                        {
                            int[] firstEven = GetFirstEven(initialArray, count);

                            if (firstEven[0] == 0)
                            {
                                Console.WriteLine("[]");
                            }

                            else
                            {
                                PrintArray(firstEven);
                            }
                        }

                        else if (manipulationCommands[2] == "odd")
                        {
                            int[] firstOdd = GetFirstOdd(initialArray, count);

                            if (firstOdd[0] == 0)
                            {
                                Console.WriteLine("[]");
                            }

                            else
                            {
                                PrintArray(firstOdd);
                            }
                        }
                    }
                }

                else if (manipulationCommands[0] == "last")
                {
                    int count = int.Parse(manipulationCommands[1]);

                    if (count > initialArray.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }

                    else
                    {
                        if (manipulationCommands[2] == "even")
                        {
                            int[] lastEven = GetLastEven(initialArray, count);

                            if (lastEven[lastEven.Length - 1] == 0)
                            {
                                Console.WriteLine("[]");
                            }

                            else
                            {
                                PrintArray(lastEven);
                            }
                        }

                        else if (manipulationCommands[2] == "odd")
                        {
                            int[] lastOdd = GetLastOdd(initialArray, count);

                            if (lastOdd[lastOdd.Length - 1] == 0)
                            {
                                Console.WriteLine("[]");
                            }

                            else
                            {
                                PrintArray(lastOdd);
                            }
                        }
                    }
                }
                               
                command = Console.ReadLine();
            }

            PrintArray(initialArray);
        }

        private static int[] Exchange(int[] initialArray, int index)
        {
            int[] subArr1 = new int[index + 1];
            int[] subArr2 = new int[initialArray.Length - (index + 1)];
            int[] arrExchanged = new int[initialArray.Length];

            for (int i = 0; i < subArr1.Length; i++)
            {
                subArr1[i] = initialArray[i];
            }

            for (int j = 0; j < subArr2.Length; j++)
            {
                subArr2[j] = initialArray[j + index + 1];
            }

            for (int k = 0; k < subArr2.Length; k++)
            {
                arrExchanged[k] = subArr2[k];
            }

            for (int l = 0; l < subArr1.Length; l++)
            {
                arrExchanged[l + subArr2.Length] = subArr1[l];
            }
            
            return arrExchanged;            
        }

        private static int GetMaxEven(int[] initialArray)
        {
            int maxEven = int.MinValue;
            int maxEvenIndex = -1;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                {
                    int currentEven = initialArray[i];
                    if (currentEven >= maxEven)
                    {
                        maxEven = currentEven;
                        maxEvenIndex = i;
                    }
                }
            }

            return maxEvenIndex;
        }

        private static int GetMaxOdd(int[] initialArray)
        {
            int maxOdd = int.MinValue;
            int maxOddIndex = -1;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                {
                    int currentOdd = initialArray[i];
                    if (currentOdd >= maxOdd)
                    {
                        maxOdd = currentOdd;
                        maxOddIndex = i;
                    }
                }
            }

            return maxOddIndex;
        }

        private static int GetMinEven(int[] initialArray)
        {
            int minEven = int.MaxValue;
            int minEvenIndex = -1;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                {
                    int currentEven = initialArray[i];
                    if (currentEven <= minEven)
                    {
                        minEven = currentEven;
                        minEvenIndex = i;
                    }
                }
            }

            return minEvenIndex;
        }

        private static int GetMinOdd(int[] initialArray)
        {
            int minOdd = int.MaxValue;
            int minOddIndex = -1;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                {
                    int currentOdd = initialArray[i];
                    if (currentOdd <= minOdd)
                    {
                        minOdd = currentOdd;
                        minOddIndex = i;
                    }
                }
            }

            return minOddIndex;
        }

        private static int[] GetFirstEven(int[] initialArray, int count)
        {
            int evenCount = 0;
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                {
                    evenCount++;
                }
            }

            if (count > evenCount && evenCount != 0)
            {
                count = evenCount;
            }

            int[] firstEven = new int[count];
            int j = 0;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                {
                    if (j < firstEven.Length)
                    {
                        firstEven[j] = initialArray[i];
                        j++;
                    }
                }
            }

            return firstEven;
        }

        private static int[] GetFirstOdd(int[] initialArray, int count)
        {
            int oddCount = 0;
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                {
                    oddCount++;
                }
            }

            if (count > oddCount && oddCount != 0)
            {
                count = oddCount;
            }

            int[] firstOdd = new int[count];
            int j = 0;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                {
                    if (j < firstOdd.Length)
                    {
                        firstOdd[j] = initialArray[i];
                        j++;
                    }
                }
            }

            return firstOdd;
        }

        private static int[] GetLastEven(int[] initialArray, int count)
        {
            int evenCount = 0;
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                {
                    evenCount++;
                }
            }

            if (count > evenCount && evenCount != 0)
            {
                count = evenCount;
            }

            int[] lastEven = new int[count];
            int j = lastEven.Length - 1;

            for (int i = initialArray.Length - 1; i >= 0; i--)
            {             
                if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                {
                    if (j >= 0)
                    {
                        lastEven[j] = initialArray[i];
                        j--;
                    }
                }
            }

            return lastEven;
        }

        private static int[] GetLastOdd(int[] initialArray, int count)
        {
            int oddCount = 0;
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                {
                    oddCount++;
                }
            }

            if (count > oddCount && oddCount != 0)
            {
                count = oddCount;
            }

            int[] lastOdd = new int[count];
            int j = lastOdd.Length - 1;

            for (int i = initialArray.Length - 1; i >= 0; i--)
            {
                if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                {
                    if (j >= 0)
                    {
                        lastOdd[j] = initialArray[i];
                        j--;
                    }
                }
            }

            return lastOdd;
        }

        private static void PrintArray(int[] arrayToPrint)
        {
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                if (i == 0 && arrayToPrint.Length == 1)
                {
                    Console.WriteLine($"[{arrayToPrint[0]}]");
                }
                else if (i == 0 && arrayToPrint.Length > 1)
                {
                    Console.Write($"[{arrayToPrint[i]}, ");
                }
                else if (i == arrayToPrint.Length - 1)
                {
                    Console.WriteLine($"{arrayToPrint[i]}]");
                }
                else
                {
                    Console.Write(arrayToPrint[i] + ", ");
                }
            }
        }
    }
}
