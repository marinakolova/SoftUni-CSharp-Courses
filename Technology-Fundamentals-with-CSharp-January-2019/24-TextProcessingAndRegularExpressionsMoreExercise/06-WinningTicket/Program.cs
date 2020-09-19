using System;
using System.Text.RegularExpressions;

namespace _06_WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] winningSymbols = new string[] { "@", "#", "$", @"\^" };

            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                bool isMatch = false;

                for (int b = 0; b < winningSymbols.Length; b++)
                {
                    string currentPattern = $@"[{winningSymbols[b]}]+";

                    string leftSideOfTicket = tickets[i].Substring(0, 10);
                    string rightSideOfTicket = tickets[i].Substring(10, 10);

                    int counterLeft = 0;
                    int counterRight = 0;


                    foreach (Match match in Regex.Matches(leftSideOfTicket, currentPattern))
                    {
                        counterLeft = match.Value.Length;
                    }
                    foreach (Match match in Regex.Matches(rightSideOfTicket, currentPattern))
                    {
                        counterRight = match.Value.Length;
                    }

                    if (counterLeft >= 6 && counterRight >= 6 && (counterLeft + counterRight) < 20)
                    {

                        if (winningSymbols[b] == @"\^")
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "^");
                        }
                        else
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "" + winningSymbols[b]);
                        }
                        isMatch = true;
                        break;
                    }
                    else if ((counterLeft + counterRight) == 20)
                    {
                        if (winningSymbols[b] == @"\^")
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "^ Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "" + winningSymbols[b] + " Jackpot!");
                        }
                        isMatch = true;
                        break;
                    }
                    else
                    {
                        isMatch = false;

                    }
                }

                if (!isMatch)
                {
                    Console.WriteLine("ticket \"" + tickets[i] + "\" - no match");
                }
            }
        }
    }
}