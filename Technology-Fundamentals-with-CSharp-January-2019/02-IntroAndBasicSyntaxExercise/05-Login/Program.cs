using System;

namespace _05_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";
                        
            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            string input = Console.ReadLine();
            int attempts = 1;

            while (input != password && attempts < 4)
            {
                Console.WriteLine("Incorrect password. Try again.");
                attempts++;
                input = Console.ReadLine();
            }

            if (input == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }

            if (attempts >= 4)
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
