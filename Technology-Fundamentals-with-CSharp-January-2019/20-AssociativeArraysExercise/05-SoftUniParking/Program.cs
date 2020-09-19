using System;
using System.Collections.Generic;

namespace _05_SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var registered = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "register")
                {
                    string username = command[1];
                    string licensePlate = command[2];

                    if (registered.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registered[username]}");
                    }
                    else
                    {
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                        registered.Add(username, licensePlate);
                    }
                }
                else if (command[0] == "unregister")
                {
                    string user = command[1];

                    if (!registered.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{user} unregistered successfully");
                        registered.Remove(user);
                    }
                }
            }

            foreach (var reg in registered)
            {
                Console.WriteLine($"{reg.Key} => {reg.Value}");
            }
        }
    }
}
