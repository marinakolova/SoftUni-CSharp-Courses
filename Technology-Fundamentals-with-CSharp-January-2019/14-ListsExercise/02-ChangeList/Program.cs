using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> theList = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] tokens = command.Split().ToArray();

                switch (tokens[0])
                {
                    case "Delete":
                        int elementToRemove = int.Parse(tokens[1]);
                        theList.RemoveAll(x => x == elementToRemove);
                        break;

                    case "Insert":
                        int elementToInsert = int.Parse(tokens[1]);
                        int indexToInsertAt = int.Parse(tokens[2]);
                        theList.Insert(indexToInsertAt, elementToInsert);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", theList));
        }
    }
}
