using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08_IncreaseMinionAge
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        private const string UpdateMinions = @"UPDATE Minions
                                                  SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                                WHERE Id = @Id";

        private const string SelectFromMinions = "SELECT Name, Age FROM Minions";

        static void Main(string[] args)
        {
            try
            {
                var inputIds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                SqlConnection connection = new SqlConnection(ConnectionString);

                using (connection)
                {
                    connection.Open();

                    // UPDATE DATABASE

                    foreach (var id in inputIds)
                    {
                        using (SqlCommand command = new SqlCommand(UpdateMinions, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }
                    }

                    // PRINT RESULT

                    using (SqlCommand command = new SqlCommand(SelectFromMinions, connection))
                    {
                        using SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var name = (string)reader[0];
                            var age = (int)reader[1];

                            Console.WriteLine($"{name} {age}");
                        }
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
