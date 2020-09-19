using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_ArrayManipulator2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> initialArray = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] partsOfCommand = command.Split().ToArray();

                switch (partsOfCommand[0])
                {
                    case "exchange":

                        int indexToExchange = int.Parse(partsOfCommand[1]);
                        if (indexToExchange >= 0 && indexToExchange < initialArray.Count)
                        {
                            for (int i = 0; i <= indexToExchange; i++)
                            {
                                initialArray.Add(initialArray[i]);
                            }
                            for (int i = 0; i <= indexToExchange; i++)
                            {
                                initialArray.RemoveAt(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;

                    case "max":

                        switch (partsOfCommand[1])
                        {
                            case "even":

                                int maxEven = int.MinValue;
                                int maxEvenIndex = -1;

                                for (int i = 0; i < initialArray.Count; i++)
                                {
                                    if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                                    {
                                        if (initialArray[i] >= maxEven)
                                        {
                                            maxEven = initialArray[i];
                                            maxEvenIndex = i;
                                        }
                                    }
                                }

                                if (maxEvenIndex != - 1)
                                {
                                    Console.WriteLine(maxEvenIndex);
                                }
                                else
                                {
                                    Console.WriteLine("No matches");
                                }

                                break;

                            case "odd":

                                int maxOdd = int.MinValue;
                                int maxOddIndex = -1;

                                for (int i = 0; i < initialArray.Count; i++)
                                {
                                    if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                                    {
                                        if (initialArray[i] >= maxOdd)
                                        {
                                            maxOdd = initialArray[i];
                                            maxOddIndex = i;
                                        }
                                    }
                                }

                                if (maxOddIndex != -1)
                                {
                                    Console.WriteLine(maxOddIndex);
                                }
                                else
                                {
                                    Console.WriteLine("No matches");
                                }

                                break;
                        }

                        break;

                    case "min":

                        switch (partsOfCommand[1])
                        {
                            case "even":

                                int minEven = int.MaxValue;
                                int minEvenIndex = -1;

                                for (int i = 0; i < initialArray.Count; i++)
                                {
                                    if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                                    {
                                        if (initialArray[i] <= minEven)
                                        {
                                            minEven = initialArray[i];
                                            minEvenIndex = i;
                                        }
                                    }
                                }

                                if (minEvenIndex != -1)
                                {
                                    Console.WriteLine(minEvenIndex);
                                }
                                else
                                {
                                    Console.WriteLine("No matches");
                                }

                                break;

                            case "odd":

                                int minOdd = int.MaxValue;
                                int minOddIndex = -1;

                                for (int i = 0; i < initialArray.Count; i++)
                                {
                                    if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                                    {
                                        if (initialArray[i] <= minOdd)
                                        {
                                            minOdd = initialArray[i];
                                            minOddIndex = i;
                                        }
                                    }
                                }

                                if (minOddIndex != -1)
                                {
                                    Console.WriteLine(minOddIndex);
                                }
                                else
                                {
                                    Console.WriteLine("No matches");
                                }

                                break;
                        }

                        break;

                    case "first":

                        int firstCount = int.Parse(partsOfCommand[1]);

                        if (firstCount > initialArray.Count)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            switch (partsOfCommand[2])
                            {
                                case "even":

                                    List<int> firstEvenElements = new List<int>();
                                    int firstEvenElementsCount = 0;

                                    for (int i = 0; i < initialArray.Count; i++)
                                    {
                                        if (firstEvenElementsCount < firstCount)
                                        {
                                            if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                                            {
                                                firstEvenElements.Add(initialArray[i]);
                                                firstEvenElementsCount++;
                                            }
                                        }
                                    }

                                    Console.WriteLine("[" + string.Join(", ", firstEvenElements) + "]");

                                    break;

                                case "odd":

                                    List<int> firstOddElements = new List<int>();
                                    int firstOddElementsCount = 0;

                                    for (int i = 0; i < initialArray.Count; i++)
                                    {
                                        if (firstOddElementsCount < firstCount)
                                        {
                                            if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                                            {
                                                firstOddElements.Add(initialArray[i]);
                                                firstOddElementsCount++;
                                            }
                                        }
                                    }

                                    Console.WriteLine("[" + string.Join(", ", firstOddElements) + "]");

                                    break;
                            }
                        }                        

                        break;

                    case "last":

                        int lastCount = int.Parse(partsOfCommand[1]);

                        if (lastCount > initialArray.Count)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            switch (partsOfCommand[2])
                            {
                                case "even":

                                    List<int> lastEvenElements = new List<int>();
                                    int lastEvenElementsCount = 0;

                                    for (int i = initialArray.Count - 1; i >= 0; i--)
                                    {
                                        if (lastEvenElementsCount < lastCount)
                                        {
                                            if (initialArray[i] != 0 && initialArray[i] % 2 == 0)
                                            {
                                                lastEvenElements.Add(initialArray[i]);
                                                lastEvenElementsCount++;
                                            }
                                        }
                                    }

                                    lastEvenElements.Reverse();
                                    Console.WriteLine("[" + string.Join(", ", lastEvenElements) + "]");

                                    break;

                                case "odd":

                                    List<int> lastOddElements = new List<int>();
                                    int lastOddElementsCount = 0;

                                    for (int i = initialArray.Count - 1; i >= 0; i--)
                                    {
                                        if (lastOddElementsCount < lastCount)
                                        {
                                            if (initialArray[i] != 0 && initialArray[i] % 2 != 0)
                                            {
                                                lastOddElements.Add(initialArray[i]);
                                                lastOddElementsCount++;
                                            }
                                        }
                                    }

                                    lastOddElements.Reverse();
                                    Console.WriteLine("[" + string.Join(", ", lastOddElements) + "]");

                                    break;
                            }
                        }

                        break;
                }
            }

            Console.WriteLine("[" + string.Join(", ", initialArray) + "]");
        }        
    }
}
