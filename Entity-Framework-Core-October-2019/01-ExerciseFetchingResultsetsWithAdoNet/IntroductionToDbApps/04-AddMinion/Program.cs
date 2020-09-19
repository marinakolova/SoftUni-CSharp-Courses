using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _04_AddMinion
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        private const string FindTownId = "SELECT Id FROM Towns WHERE Name = @townName";
        private const string InsertIntoTowns = "INSERT INTO Towns(Name) VALUES(@townName)";

        private const string FindMinionId = "SELECT Id FROM Minions WHERE Name = @Name";
        private const string InsertIntoMinions = "INSERT INTO Minions(Name, Age, TownId) VALUES(@nam, @age, @townId)";

        private const string FindVillainId = "SELECT Id FROM Villains WHERE Name = @Name";
        private const string InsertIntoVillains = "INSERT INTO Villains(Name, EvilnessFactorId)  VALUES(@villainName, 4)";
        
        private const string InsertIntoMinionsVillains = "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@villainId, @minionId)";

        static void Main(string[] args)
        {
            try
            {
                var minionInfo = Console.ReadLine()
                    ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToList();

                var minionName = minionInfo?[0];
                var minionAge = int.Parse(minionInfo?[1] ?? throw new InvalidOperationException());
                var townName = minionInfo?[2];

                var villainInfo = Console.ReadLine()
                    ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToList();

                var villainName = villainInfo?[0];

                var townId = 0;
                var minionId = 0;
                var villainId = 0;

                SqlConnection connection = new SqlConnection(ConnectionString);

                using (connection)
                {
                    connection.Open();

                    // FIND OR ADD TOWN

                    using (SqlCommand command = new SqlCommand(FindTownId, connection))
                    {
                        command.Parameters.AddWithValue("@townName", townName);

                        if (command.ExecuteScalar() != null)
                        {
                            townId = (int)command.ExecuteScalar();
                        }
                    }

                    if (townId == 0)
                    {
                        using (SqlCommand command = new SqlCommand(InsertIntoTowns, connection))
                        {
                            command.Parameters.AddWithValue("@townName", townName);

                            command.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand(FindTownId, connection))
                        {
                            command.Parameters.AddWithValue("@townName", townName);

                            townId = (int)command.ExecuteScalar();
                        }

                        Console.WriteLine($"Town {townName} was added to the database.");
                    }

                    // FIND OR ADD MINION

                    using (SqlCommand command = new SqlCommand(FindMinionId, connection))
                    {
                        command.Parameters.AddWithValue("@Name", minionName);

                        if (command.ExecuteScalar() != null)
                        {
                            minionId = (int)command.ExecuteScalar();
                        }
                    }

                    if (minionId == 0)
                    {
                        using (SqlCommand command = new SqlCommand(InsertIntoMinions, connection))
                        {
                            command.Parameters.AddWithValue("@nam", minionName);
                            command.Parameters.AddWithValue("@age", minionAge);
                            command.Parameters.AddWithValue("@townId", townId);

                            command.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand(FindMinionId, connection))
                        {
                            command.Parameters.AddWithValue("@Name", minionName);

                            minionId = (int)command.ExecuteScalar();
                        }
                    }

                    // FIND OR ADD VILLAIN

                    using (SqlCommand command = new SqlCommand(FindVillainId, connection))
                    {
                        command.Parameters.AddWithValue("@Name", villainName);

                        if (command.ExecuteScalar() != null)
                        {
                            villainId = (int)command.ExecuteScalar();
                        }
                    }

                    if (villainId == 0)
                    {
                        using (SqlCommand command = new SqlCommand(InsertIntoVillains, connection))
                        {
                            command.Parameters.AddWithValue("@villainName", villainName);

                            command.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand(FindVillainId, connection))
                        {
                            command.Parameters.AddWithValue("@Name", villainName);

                            villainId = (int)command.ExecuteScalar();
                        }

                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }

                    // MAKE THE MINION SERVANT OF THE VILLAIN

                    using (SqlCommand command = new SqlCommand(InsertIntoMinionsVillains, connection))
                    {
                        command.Parameters.AddWithValue("@villainId", villainId);
                        command.Parameters.AddWithValue("@minionId", minionId);

                        Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
