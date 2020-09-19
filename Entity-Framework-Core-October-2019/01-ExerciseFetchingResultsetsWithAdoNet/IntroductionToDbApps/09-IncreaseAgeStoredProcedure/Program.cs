using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace _09_IncreaseAgeStoredProcedure
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        // TODO: Create stored procedure usp_GetOlder (directly in the database using MSSMS)
        //CREATE PROC usp_GetOlder @id INT
        //    AS
        //UPDATE Minions
        //SET Age += 1
        //WHERE Id = @id

        private const string SelectFromMinions = "SELECT Name, Age FROM Minions WHERE Id = @id";

        static void Main(string[] args)
        {
            try
            {
                var id = int.Parse(Console.ReadLine());
                
                SqlConnection connection = new SqlConnection(ConnectionString);

                using (connection)
                {
                    connection.Open();

                    // USE THE STORED PROCEDURE

                    using (SqlCommand command = new SqlCommand("usp_GetOlder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }

                    // PRINT RESULT

                    using (SqlCommand command = new SqlCommand(SelectFromMinions, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var name = (string)reader[0];
                            var age = (int)reader[1];

                            Console.WriteLine($"{name} – {age} years old");
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
