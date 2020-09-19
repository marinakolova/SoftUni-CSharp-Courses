using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            var listOfContests = new Dictionary<string, string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of contests")
                {
                    break;
                }

                string[] partsOfCommand = command.Split(":");
                string contest = partsOfCommand[0];
                string password = partsOfCommand[1];

                listOfContests.Add(contest, password);
            }

            var listOfUsers = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of submissions")
                {
                    break;
                }

                string[] partsOfCommand = command.Split("=>");
                string contest = partsOfCommand[0];
                string password = partsOfCommand[1];
                string username = partsOfCommand[2];
                int points = int.Parse(partsOfCommand[3]);

                if (listOfContests.ContainsKey(contest))
                {
                    if (listOfContests[contest] == password)
                    {
                        if (!listOfUsers.ContainsKey(username))
                        {
                            listOfUsers.Add(username, new Dictionary<string, int>());
                        }

                        if (!listOfUsers[username].ContainsKey(contest))
                        {
                            listOfUsers[username].Add(contest, points);
                        }
                        else
                        {
                            if (listOfUsers[username][contest] < points)
                            {
                                listOfUsers[username][contest] = points;
                            }
                        }
                    }
                }
            }

            var totalPoints = new SortedDictionary<int, string>();

            foreach (var user in listOfUsers)
            {
                int usersTotalPoints = user.Value.Sum(x => x.Value);
                totalPoints.Add(usersTotalPoints, user.Key);
            }

            string bestUser = totalPoints.Reverse().Take(1).Select(d => d.Value).First();
            int bestPoints = totalPoints.Reverse().Take(1).Select(d => d.Key).First();

            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in listOfUsers)
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
