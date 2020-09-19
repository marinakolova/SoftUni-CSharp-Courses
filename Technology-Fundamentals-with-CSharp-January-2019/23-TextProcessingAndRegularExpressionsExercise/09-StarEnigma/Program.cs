using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var encryptedMessages = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var message = Console.ReadLine();
                encryptedMessages.Add(message);
            }

            var decryptedMessages = new List<string>();

            foreach (var message in encryptedMessages)
            {
                var keyLettersCount = 0;
                var decryptedMessage = "";

                for (int i = 0; i < message.Length; i++)
                {
                    if (message[i] == 's'
                            || message[i] == 'S'
                            || message[i] == 't'
                            || message[i] == 'T'
                            || message[i] == 'a'
                            || message[i] == 'A'
                            || message[i] == 'r'
                            || message[i] == 'R')
                    {
                        keyLettersCount++;
                    }
                }

                for (int j = 0; j < message.Length; j++)
                {
                    var currChar = message[j];
                    var newChar = currChar - keyLettersCount;

                    decryptedMessage += (char)newChar;
                }

                decryptedMessages.Add(decryptedMessage);
            }

            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            foreach (var decryptedMessage in decryptedMessages)
            {
                bool isValidMessage = true;
                var planetName = "";
                var population = "";
                var attackType = "";
                var soldiersCount = "";

                var planetNameIndex = decryptedMessage.IndexOf('@');

                if (planetNameIndex == -1)
                {
                    isValidMessage = false;
                }
                else
                {
                    var planetNameSubstr = decryptedMessage.Substring(planetNameIndex + 1);

                    for (int i = 0; i < planetNameSubstr.Length; i++)
                    {
                        if (char.IsLetter(planetNameSubstr[i]))
                        {
                            planetName += planetNameSubstr[i];
                        }
                        else
                        {
                            break;
                        }
                    }

                    var populationIndex = planetNameSubstr.IndexOf(':');

                    if (populationIndex == -1)
                    {
                        isValidMessage = false;
                    }
                    else
                    {
                        var populationSubstr = planetNameSubstr.Substring(populationIndex + 1);

                        for (int i = 0; i < populationSubstr.Length; i++)
                        {
                            if (char.IsDigit(populationSubstr[i]))
                            {
                                population += populationSubstr[i];
                            }
                            else
                            {
                                break;
                            }
                        }

                        var attackTypeIndex = populationSubstr.IndexOf('!');

                        if (attackTypeIndex == -1)
                        {
                            isValidMessage = false;
                        }
                        else
                        {
                            var attackTypeSubst = populationSubstr.Substring(attackTypeIndex + 1);

                            if ((attackTypeSubst[0] == 'A' || attackTypeSubst[0] == 'D') && attackTypeSubst[1] == '!')
                            {
                                attackType += attackTypeSubst[0];
                            }
                            else
                            {
                                isValidMessage = false;
                            }

                            var soldiersCountIndex = attackTypeSubst.IndexOf("->");

                            if (soldiersCountIndex == -1)
                            {
                                isValidMessage = false;
                            }
                            else
                            {
                                var soldiersCountSubstr = attackTypeSubst.Substring(soldiersCountIndex + 2);

                                for (int i = 0; i < soldiersCountSubstr.Length; i++)
                                {
                                    if (char.IsDigit(soldiersCountSubstr[i]))
                                    {
                                        soldiersCount += soldiersCountSubstr[i];
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (planetName.Length == 0
                        || population.Length == 0
                        || attackType.Length == 0
                        || soldiersCount.Length == 0)
                {
                    isValidMessage = false;
                }

                if (isValidMessage)
                {
                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    if (attackType == "D")
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets = attackedPlanets.OrderBy(x => x).ToList();
            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            destroyedPlanets = destroyedPlanets.OrderBy(x => x).ToList();
            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
