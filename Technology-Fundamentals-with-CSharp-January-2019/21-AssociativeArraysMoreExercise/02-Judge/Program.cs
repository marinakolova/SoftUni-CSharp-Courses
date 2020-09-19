using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfContests = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "no more time")
                {
                    break;
                }

                string[] partsOfCommand = command.Split(" -> ");
                string username = partsOfCommand[0];
                string contest = partsOfCommand[1];
                int points = int.Parse(partsOfCommand[2]);

                if (!listOfContests.ContainsKey(contest))
                {
                    listOfContests.Add(contest, new Dictionary<string, int>());
                }
                if (!listOfContests[contest].ContainsKey(username))
                {
                    listOfContests[contest].Add(username, 0);
                }
                if (listOfContests[contest][username] < points)
                {
                    listOfContests[contest][username] = points;
                }
            }

            foreach (var contest in listOfContests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                Dictionary<string, int> orderedList = contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(t => t.Key, t => t.Value);
                List<string> userss = orderedList.Keys.ToList();
                List<int> pointss = orderedList.Values.ToList();

                for (int i = 0; i < contest.Value.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {userss[i]} <::> {pointss[i]}");
                }
            }

            var listOfUsers = new Dictionary<string, int>();

            foreach (var contest in listOfContests)
            {
                foreach (var user in contest.Value)
                {
                    if (!listOfUsers.ContainsKey(user.Key))
                    {
                        listOfUsers.Add(user.Key, 0);
                    }
                    listOfUsers[user.Key] += user.Value;
                }
            }

            Console.WriteLine("Individual standings:");
            Dictionary<string, int> orderedListOfUsers = listOfUsers.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(t => t.Key, t => t.Value);
            List<string> usersss = orderedListOfUsers.Keys.ToList();
            List<int> pointsss = orderedListOfUsers.Values.ToList();

            for (int i = 0; i < orderedListOfUsers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {usersss[i]} -> {pointsss[i]}");
            }
        }
    }
}