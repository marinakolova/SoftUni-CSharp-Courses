using System;
using System.Collections.Generic;

namespace _01_ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = Console.ReadLine().Split(", ");
            var validUsernames = new List<string>();

            foreach (var usename in usernames)
            {
                bool isValid = true;

                if (usename.Length < 3 || usename.Length > 16)
                {
                    isValid = false;
                }

                else
                {
                    for (int i = 0; i < usename.Length; i++)
                    {
                        if (!char.IsLetterOrDigit(usename[i]) && usename[i] != '-' && usename[i] != '_')
                        {
                            isValid = false;
                        }
                    }
                }                

                if (isValid)
                {
                    validUsernames.Add(usename);
                }
            }

            foreach (var username in validUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
