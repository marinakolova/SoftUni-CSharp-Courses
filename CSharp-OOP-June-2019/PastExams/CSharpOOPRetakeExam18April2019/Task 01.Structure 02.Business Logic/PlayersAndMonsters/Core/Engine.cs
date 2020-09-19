using System;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IManagerController managerController;

        public Engine(IReader reader, 
            IWriter writer, 
            IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine();

                if (input == "Exit")
                {
                    break;
                }

                var command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string result = " ";

                try
                {
                    switch (command[0])
                    {
                        case "AddPlayer":
                            var playerType = command[1];
                            var username = command[2];
                            result = managerController.AddPlayer(playerType, username);
                            break;

                        case "AddCard":
                            var cardType = command[1];
                            var name = command[2];
                            result = managerController.AddCard(cardType, name);
                            break;

                        case "AddPlayerCard":
                            var player = command[1];
                            var card = command[2];
                            result = managerController.AddPlayerCard(player, card);
                            break;

                        case "Fight":
                            var attackUser = command[1];
                            var enemyUser = command[2];
                            result = managerController.Fight(attackUser, enemyUser);
                            break;

                        case "Report":
                            result = managerController.Report();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                writer.WriteLine(result);
            }
        }
    }
}
