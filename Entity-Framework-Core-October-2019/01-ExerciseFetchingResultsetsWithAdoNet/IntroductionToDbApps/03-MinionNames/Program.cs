using System;
using System.Data.SqlClient;

namespace _03_MinionNames
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        private const string VillainName = "SELECT Name FROM Villains WHERE Id = @Id";

        private const string MinionsNames = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                     m.Name,
                                                     m.Age
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id
                                               WHERE mv.VillainId = @Id
                                            ORDER BY m.Name";

        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using SqlConnection connection = new SqlConnection(ConnectionString);
            
            connection.Open();

            using (SqlCommand commandVillain = new SqlCommand(VillainName, connection))
            {
                commandVillain.Parameters.AddWithValue("@Id", id);

                string villainName = (string)commandVillain.ExecuteScalar();

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }

                Console.WriteLine($"Villain: {villainName}");
            }

            using SqlCommand commandMinions = new SqlCommand(MinionsNames, connection);

            commandMinions.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = commandMinions.ExecuteReader();
            
            if (!reader.HasRows)
            {
                Console.WriteLine("(no minions)");
                return;
            }

            while (reader.Read())
            {
                long row = (long)reader[0];
                string name = (string)reader[1];
                int age = (int)reader[2];

                Console.WriteLine($"{row}. {name} {age}");
            }
        }
    }
}
