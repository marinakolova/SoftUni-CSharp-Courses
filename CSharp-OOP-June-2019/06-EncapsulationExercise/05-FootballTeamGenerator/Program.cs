using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var partsOfCommand = command.Split(";");

                switch (partsOfCommand[0])
                {
                    case "Team":
                        try
                        {
                            teams.Add(new Team(partsOfCommand[1]));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Add":
                        var teamName = partsOfCommand[1];
                        var playerName = partsOfCommand[2];
                        var endurance = int.Parse(partsOfCommand[3]);
                        var sprint = int.Parse(partsOfCommand[4]);
                        var dribble = int.Parse(partsOfCommand[5]);
                        var passing = int.Parse(partsOfCommand[6]);
                        var shooting = int.Parse(partsOfCommand[7]);
                        if (teams.Where(t => t.Name == teamName).FirstOrDefault() == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                teams.Where(t => t.Name == teamName).FirstOrDefault()
                                    .AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case "Remove":
                        if (teams.Where(t => t.Name == partsOfCommand[1]).FirstOrDefault() == null)
                        {
                            Console.WriteLine($"Team {partsOfCommand[1]} does not exist.");
                        }
                        else
                        {
                            try
                            {
                                teams.Where(t => t.Name == partsOfCommand[1]).FirstOrDefault()
                                    .RemovePlayer(partsOfCommand[2]);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    case "Rating":
                        if (teams.Where(t => t.Name == partsOfCommand[1]).FirstOrDefault() == null)
                        {
                            Console.WriteLine($"Team {partsOfCommand[1]} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine(teams.Where(t => t.Name == partsOfCommand[1]).FirstOrDefault());
                        }
                        break;
                }
            }
        }
    }
}
