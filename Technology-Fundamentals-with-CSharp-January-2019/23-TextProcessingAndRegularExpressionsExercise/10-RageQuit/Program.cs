using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            var output = new StringBuilder();

            string customString = "";

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];

                if (!char.IsDigit(currChar))
                {
                    if (char.IsLetter(currChar))
                    {
                        currChar = char.ToUpper(currChar);
                    }                    

                    customString += currChar;
                }

                else if (char.IsDigit(currChar))
                {
                    if (i != input.Length - 1)
                    {
                        char nextChar = input[i + 1];

                        if (!char.IsDigit(nextChar))
                        {
                            int count = int.Parse(currChar.ToString());

                            for (int j = 0; j < count; j++)
                            {
                                output.Append(customString);
                            }

                            customString = "";
                        }

                        else if (char.IsDigit(nextChar))
                        {
                            string stringCount = currChar.ToString() + nextChar.ToString();
                            int count = int.Parse(stringCount);

                            for (int j = 0; j < count; j++)
                            {
                                output.Append(customString);
                            }

                            customString = "";
                            i++;
                        }
                    }

                    else
                    {
                        int count = int.Parse(currChar.ToString());

                        for (int j = 0; j < count; j++)
                        {
                            output.Append(customString);
                        }

                        customString = "";
                    }                       
                }
            }

            char[] uniqueChars = output.ToString().ToCharArray().Distinct().ToArray();

            Console.WriteLine($"Unique symbols used: {uniqueChars.Length}");
            Console.WriteLine(output);
        }
    }
}
