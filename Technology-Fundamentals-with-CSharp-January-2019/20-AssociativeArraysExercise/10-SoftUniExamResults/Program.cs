using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfUsers = new Dictionary<string, int>();
            var listOfLanguages = new Dictionary<string, int>();

            List<string> bannedUsers = new List<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "exam finished")
                {
                    break;
                }

                string[] partsOfCommand = command.Split("-");
                string username = partsOfCommand[0];

                if (partsOfCommand[1] == "banned")
                {
                    bannedUsers.Add(username);
                }
                else
                {
                    string language = partsOfCommand[1];
                    int points = int.Parse(partsOfCommand[2]);

                    if (!listOfUsers.ContainsKey(username))
                    {
                        listOfUsers.Add(username, 0);
                    }
                    if (listOfUsers[username] < points)
                    {
                        listOfUsers[username] = points;
                    }                    

                    if (!listOfLanguages.ContainsKey(language))
                    {
                        listOfLanguages.Add(language, 0);
                    }
                    listOfLanguages[language]++;
                }                
            }

            for (int i = 0; i < bannedUsers.Count; i++)
            {
                string userToBan = bannedUsers[i];

                if (listOfUsers.ContainsKey(userToBan))
                {
                    listOfUsers.Remove(userToBan);
                }
            }

            Console.WriteLine("Results:");
            foreach (var student in listOfUsers.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in listOfLanguages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
