using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07_PrintAllMinionNames
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        private const string Query = "SELECT Name FROM Minions";

        static void Main(string[] args)
        {
            try
            {
                var minionsNames = new List<string>();
                
                SqlConnection connection = new SqlConnection(ConnectionString);

                using (connection)
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        using SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            minionsNames.Add((string)reader[0]);
                        }
                    }
                }

                while (minionsNames.Count > 0)
                {
                    if (minionsNames.Count >= 2)
                    {
                        Console.WriteLine(minionsNames[0]);
                        Console.WriteLine(minionsNames[minionsNames.Count - 1]);

                        minionsNames.RemoveAt(0);
                        minionsNames.RemoveAt(minionsNames.Count - 1);
                    }

                    else if(minionsNames.Count == 1)
                    {
                        Console.WriteLine(minionsNames[0]);

                        minionsNames.RemoveAt(0);
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
