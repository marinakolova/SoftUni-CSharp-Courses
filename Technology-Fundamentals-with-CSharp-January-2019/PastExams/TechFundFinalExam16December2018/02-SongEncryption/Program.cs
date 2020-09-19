using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02_SongEncryption // 90/100
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (Regex.IsMatch(command, @"^[A-Z]+[a-z'\s]+[:]{1}[A-Z\s]+$"))
                {
                    var splitArtist = command.Split(":");
                    int key = splitArtist[0].Length;
                    StringBuilder line = new StringBuilder(command);

                    for (int i = 0; i < line.Length; i++)
                    {
                        int currCharAsInt = (int)line[i];
                        int newCharAsInt = currCharAsInt;

                        if (currCharAsInt >= 97 && currCharAsInt <= 122)
                        {
                            newCharAsInt += key;
                            if (newCharAsInt > 122)
                            {
                                newCharAsInt -= 26;
                            }
                        }
                        else if (currCharAsInt >= 65 && currCharAsInt <= 90)
                        {
                            newCharAsInt += key;
                            if (newCharAsInt > 90)
                            {
                                newCharAsInt -= 26;
                            }
                        }
                        else if ((char)currCharAsInt == ':')
                        {
                            newCharAsInt = (int)'@';
                        }
                        else if ((char)currCharAsInt == '\'')
                        {
                            newCharAsInt = (int)'\'';
                        }
                        else if (currCharAsInt == 32)
                        {
                            newCharAsInt = 32;
                        }

                        line[i] = (char)newCharAsInt;
                    }

                    Console.WriteLine($"Successful encryption: {line}");
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
