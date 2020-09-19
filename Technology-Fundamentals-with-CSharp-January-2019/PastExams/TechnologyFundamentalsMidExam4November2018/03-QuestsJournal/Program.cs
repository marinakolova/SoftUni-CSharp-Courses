using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_QuestsJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Retire!")
                {
                    break;
                }

                string[] partsOfCommand = command.Split(" - ");

                switch (partsOfCommand[0])
                {
                    case "Start":

                        string questToAdd = partsOfCommand[1];

                        if (!journal.Contains(questToAdd))
                        {
                            journal.Add(questToAdd);
                        }

                        break;

                    case "Complete":

                        string questToRemove = partsOfCommand[1];

                        if (journal.Contains(questToRemove))
                        {
                            journal.Remove(questToRemove);
                        }

                        break;

                    case "Side Quest":

                        string[] subpartsOfCommand = partsOfCommand[1].Split(":");
                        string questToAddAfter = subpartsOfCommand[0];
                        string sideQuestToAdd = subpartsOfCommand[1];

                        if (journal.Contains(questToAddAfter) && !journal.Contains(sideQuestToAdd))
                        {
                            int indexOfQuestToAddAfter = journal.FindIndex(x => x == questToAddAfter);
                            journal.Insert(indexOfQuestToAddAfter + 1, sideQuestToAdd);
                        }

                        break;

                    case "Renew":

                        string questToMove = partsOfCommand[1];

                        if (journal.Contains(questToMove))
                        {
                            int indexOfQuestToMove = journal.FindIndex(x => x == questToMove);
                            journal.Add(journal[indexOfQuestToMove]);
                            journal.RemoveAt(indexOfQuestToMove);
                        }

                        break;
                }                
            }

            Console.WriteLine(String.Join(", ", journal));
        }
    }
}
