using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> createdTeams = new List<Team>();
            List<string> teamNames = new List<string>();
            List<string> creators = new List<string>();
            List<string> members = new List<string>();

            int numOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfTeams; i++)
            {
                string[] teamToRegister = Console.ReadLine().Split("-");

                Team newTeam = new Team();
                newTeam.Creator = teamToRegister[0];
                newTeam.TeamName = teamToRegister[1];
                newTeam.Members = new List<string>();

                if (!teamNames.Contains(newTeam.TeamName) && !creators.Contains(newTeam.Creator))
                {
                    createdTeams.Add(newTeam);
                    teamNames.Add(newTeam.TeamName);
                    creators.Add(newTeam.Creator);

                    Console.WriteLine($"Team {newTeam.TeamName} has been created by {newTeam.Creator}!");
                }

                else if (teamNames.Contains(newTeam.TeamName))
                {
                    Console.WriteLine($"Team {newTeam.TeamName} was already created!");
                }

                else if (creators.Contains(newTeam.Creator))
                {
                    Console.WriteLine($"{newTeam.Creator} cannot create another team!");
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] membersToJoin = input.Split("->");
                string newMember = membersToJoin[0];
                string wantedTeam = membersToJoin[1];

                if (teamNames.Contains(wantedTeam) && !members.Contains(newMember) && !creators.Contains(newMember))
                {
                    int indexOfTeam = createdTeams.FindIndex(x => x.TeamName == wantedTeam);
                    createdTeams[indexOfTeam].Members.Add(newMember);
                    members.Add(newMember);
                }

                else if (!teamNames.Contains(wantedTeam))
                {
                    Console.WriteLine($"Team {wantedTeam} does not exist!");
                }

                else if (members.Contains(newMember) || creators.Contains(newMember))
                {
                    Console.WriteLine($"Member {newMember} cannot join team {wantedTeam}!");
                }
            }

            List<Team> teamsToDisband = new List<Team>();
            List<Team> teamsToPrint = new List<Team>();

            foreach (var team in createdTeams)
            {
                if (team.Members.Count == 0)
                {
                    teamsToDisband.Add(team);
                }
                else
                {
                    teamsToPrint.Add(team);
                }
            }

            teamsToPrint = teamsToPrint.OrderByDescending(x => x.Members.Count).ThenBy(y => y.TeamName).ToList();
            teamsToDisband = teamsToDisband.OrderBy(x => x.TeamName).ToList();

            foreach (var team in teamsToPrint)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                team.Members.Sort();
                foreach (var member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
