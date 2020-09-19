using System;
using System.Data.SqlClient;

namespace _02_VillainNames
{
    class Program
    {
        private const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

        private const string Query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                         FROM Villains AS v 
                                         JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                     GROUP BY v.Id, v.Name 
                                       HAVING COUNT(mv.VillainId) > 3 
                                     ORDER BY COUNT(mv.VillainId)";

        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            
            connection.Open();

            using SqlCommand command = new SqlCommand(Query, connection);
            
            using SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                string name = (string)reader[0];
                int count = (int)reader[1];

                Console.Write($"{name} - {count}");
            }
        }
    }
}
