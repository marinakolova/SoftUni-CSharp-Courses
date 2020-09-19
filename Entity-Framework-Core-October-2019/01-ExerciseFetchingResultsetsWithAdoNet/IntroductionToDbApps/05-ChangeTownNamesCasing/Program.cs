using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05_ChangeTownNamesCasing
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        private const string FindCountryId = "SELECT Id FROM Countries WHERE Name = @countryName";

        private const string UpdateTowns = @"UPDATE Towns
                                                SET Name = UPPER(Name)
                                              WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        private const string FindUpdatedTowns = @"SELECT t.Name 
                                                    FROM Towns as t
                                                    JOIN Countries AS c ON c.Id = t.CountryCode
                                                   WHERE c.Name = @countryName";

        static void Main(string[] args)
        {
            try
            { 
                var countryName = Console.ReadLine();

                var countryId = 0;

                SqlConnection connection = new SqlConnection(ConnectionString);

                using (connection)
                {
                    connection.Open();

                    // FIND IF THE COUNTRY EXISTS

                    using (SqlCommand command = new SqlCommand(FindCountryId, connection))
                    {
                        command.Parameters.AddWithValue("@countryName", countryName);

                        if (command.ExecuteScalar() != null)
                        {
                            countryId = (int)command.ExecuteScalar();
                        }
                    }

                    if (countryId == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                        Environment.Exit(0);
                    }

                    // UPDATE NAMES

                    using (SqlCommand command = new SqlCommand(UpdateTowns, connection))
                    {
                        command.Parameters.AddWithValue("@countryName", countryName);

                        var townsAffected = command.ExecuteNonQuery();

                        if (townsAffected == 0)
                        {
                            Console.WriteLine("No town names were affected.");
                            Environment.Exit(0);
                        }

                        // PRINT RESULT

                        Console.WriteLine($"{townsAffected} town names were affected.");

                        using (SqlCommand commandFinal = new SqlCommand(FindUpdatedTowns, connection))
                        {
                            commandFinal.Parameters.AddWithValue("@countryName", countryName);

                            var updatedTowns = new List<string>();

                            using SqlDataReader reader = commandFinal.ExecuteReader();

                            while (reader.Read())
                            {
                                updatedTowns.Add((string)reader[0]);
                            }

                            Console.Write("[");
                            Console.Write(string.Join(", ", updatedTowns));
                            Console.WriteLine("]");
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
