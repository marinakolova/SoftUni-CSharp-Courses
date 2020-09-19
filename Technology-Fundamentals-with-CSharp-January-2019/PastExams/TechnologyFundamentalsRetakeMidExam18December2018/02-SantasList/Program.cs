using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_SantasList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> noisyKids = Console.ReadLine().Split("&").ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Finished!")
                {
                    break;
                }

                string[] partsOfCommand = command.Split();

                switch (partsOfCommand[0])
                {
                    case "Bad":
                        string kidToAdd = partsOfCommand[1];
                        if (!noisyKids.Contains(kidToAdd))
                        {
                            noisyKids.Insert(0, kidToAdd);
                        }
                        break;

                    case "Good":
                        string kidToRemove = partsOfCommand[1];
                        if (noisyKids.Contains(kidToRemove))
                        {
                            noisyKids.Remove(kidToRemove);
                        }
                        break;

                    case "Rename":
                        string oldName = partsOfCommand[1];
                        string newName = partsOfCommand[2];
                        if (noisyKids.Contains(oldName))
                        {
                            int indexOfKidToRename = noisyKids.FindIndex(x => x == oldName);
                            noisyKids.Insert(indexOfKidToRename, newName);
                            noisyKids.Remove(oldName);
                        }
                        break;

                    case "Rearrange":
                        string kidToMove = partsOfCommand[1];
                        if (noisyKids.Contains(kidToMove))
                        {
                            noisyKids.Remove(kidToMove);
                            noisyKids.Add(kidToMove);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", noisyKids));
        }
    }
}
