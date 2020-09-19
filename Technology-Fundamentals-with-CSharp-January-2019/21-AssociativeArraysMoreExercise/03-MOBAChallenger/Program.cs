using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfPlayers = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "Season end")
                {
                    break;
                }

                string[] partsOfCommand = command.Split();

                if (partsOfCommand[1] == "->")
                {
                    string player = partsOfCommand[0];                    
                    string position = partsOfCommand[2];
                    int skill = int.Parse(partsOfCommand[4]);

                    if (listOfPlayers.ContainsKey(player))
                    {
                        if (listOfPlayers[player].ContainsKey(position))
                        {
                            if (listOfPlayers[player][position] < skill)
                            {
                                listOfPlayers[player][position] = skill;
                            }
                        }
                        else
                        {
                            listOfPlayers[player].Add(position, skill);
                        }                    
                    }
                    else
                    {
                        listOfPlayers.Add(player, new Dictionary<string, int>());
                        listOfPlayers[player].Add(position, skill);
                    }                    
                }

                else if (partsOfCommand[1] == "vs")
                {
                    string playerOne = partsOfCommand[0];
                    string playerTwo = partsOfCommand[2];

                    if (listOfPlayers.ContainsKey(playerOne) && listOfPlayers.ContainsKey(playerTwo))
                    {
                        bool haveCommonPosition = false;

                        foreach (var position in listOfPlayers[playerOne].Keys)
                        {
                            if (listOfPlayers[playerTwo].ContainsKey(position))
                            {
                                haveCommonPosition = true;
                            }
                        }

                        if (haveCommonPosition)
                        {
                            int playerOneTotalSkill = listOfPlayers[playerOne].Sum(x => x.Value);
                            int playerTwoTotalSkill = listOfPlayers[playerTwo].Sum(x => x.Value);

                            if (playerOneTotalSkill > playerTwoTotalSkill)
                            {
                                listOfPlayers.Remove(playerTwo);
                            }
                            else if (playerOneTotalSkill < playerTwoTotalSkill)
                            {
                                listOfPlayers.Remove(playerOne);
                            }
                        }
                    }
                }
            }

            foreach (var player in listOfPlayers.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
