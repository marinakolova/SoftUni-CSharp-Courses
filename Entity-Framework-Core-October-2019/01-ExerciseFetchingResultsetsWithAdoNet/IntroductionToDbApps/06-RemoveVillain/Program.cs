using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace _06_RemoveVillain
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        private const string FindVillainName = "SELECT Name FROM Villains WHERE Id = @villainId";

        private const string DeleteFromMinionsVillains = @"DELETE FROM MinionsVillains 
                                                            WHERE VillainId = @villainId";

        private const string DeleteFromVillains = @"DELETE FROM Villains
                                                     WHERE Id = @villainId";

        static void Main(string[] args)
        {
            try
            {
                var villainId = int.Parse(Console.ReadLine());

                string villainName = null;
                int releasedMinions = 0;

                SqlConnection connection = new SqlConnection(ConnectionString);

                using (connection)
                {
                    connection.Open();

                    // FIND VILLAIN

                    using (SqlCommand command = new SqlCommand(FindVillainName, connection))
                    {
                        command.Parameters.AddWithValue("@villainId", villainId);

                        if (command.ExecuteScalar() != null)
                        {
                            villainName = (string)command.ExecuteScalar();
                        }
                    }

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        Environment.Exit(0);
                    }

                    // RELEASE MINIONS

                    using (SqlCommand command = new SqlCommand(DeleteFromMinionsVillains, connection))
                    {
                        command.Parameters.AddWithValue("@villainId", villainId);

                        releasedMinions = command.ExecuteNonQuery();
                    }

                    // DELETE VILLAIN

                    using (SqlCommand command = new SqlCommand(DeleteFromVillains, connection))
                    {
                        command.Parameters.AddWithValue("@villainId", villainId);

                        command.ExecuteNonQuery();
                    }

                    // PRINT RESULT

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{releasedMinions} minions were released.");
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
