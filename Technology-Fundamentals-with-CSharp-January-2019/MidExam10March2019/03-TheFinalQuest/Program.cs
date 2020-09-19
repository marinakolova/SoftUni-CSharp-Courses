using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03_TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Stop")
                {
                    break;
                }

                string[] partsOfCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (partsOfCommand[0])
                {
                    case "Delete":

                        int givenIndex = int.Parse(partsOfCommand[1]);
                        int indexToRemove = givenIndex + 1;

                        if (indexToRemove >= 0 && indexToRemove < words.Count)
                        {
                            words.RemoveAt(indexToRemove);
                        }

                        break;

                    case "Swap":

                        string word1 = partsOfCommand[1];
                        string word2 = partsOfCommand[2];

                        if (words.Contains(word1) && words.Contains(word2))
                        {
                            int indexOfWord1 = words.FindIndex(x => x == word1);
                            int indexOfWord2 = words.FindIndex(x => x == word2);

                            words.Insert(indexOfWord1, word2);
                            words.RemoveAt(indexOfWord1 + 1);

                            words.Insert(indexOfWord2, word1);
                            words.RemoveAt(indexOfWord2 + 1);
                        }

                        break;

                    case "Put":

                        string wordToInsert = partsOfCommand[1];
                        int givenIndexx = int.Parse(partsOfCommand[2]);
                        int indexToInsertAt = givenIndexx - 1;

                        if (indexToInsertAt >= 0 && indexToInsertAt < words.Count)
                        {
                            words.Insert(indexToInsertAt, wordToInsert);
                        }
                        else if (indexToInsertAt == words.Count)
                        {
                            words.Add(wordToInsert);
                        }

                        break;

                    case "Sort":

                        words.Sort(StringComparer.InvariantCultureIgnoreCase);
                        words.Reverse();

                        break;

                    case "Replace":

                        string wordToReplace = partsOfCommand[2];
                        string wordToReplaceWith = partsOfCommand[1];

                        if (words.Contains(wordToReplace))
                        {
                            int indexOfWordToReplace = words.FindIndex(x => x == wordToReplace);
                            words.Insert(indexOfWordToReplace, wordToReplaceWith);
                            words.RemoveAt(indexOfWordToReplace + 1);
                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
