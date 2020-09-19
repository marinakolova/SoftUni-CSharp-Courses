using System;

namespace _07_StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                int strength = 0;

                if (line[i] == '>')
                {
                    switch (line[i + 1])
                    {
                        case '0':
                            strength = 0;
                            break;
                        case '1':
                            strength = 1;                            
                            break;
                        case '2':
                            strength = 2;                            
                            break;
                        case '3':
                            strength = 3;
                            break;
                        case '4':
                            strength = 4;
                            break;
                        case '5':
                            strength = 5;
                            break;
                        case '6':
                            strength = 6;
                            break;
                        case '7':
                            strength = 7;
                            break;
                        case '8':
                            strength = 8;
                            break;
                        case '9':
                            strength = 9;
                            break;
                    }

                    for (int j = 0; j <= strength; j++)
                    {
                        while (line[i + 1 + j] != '>' && strength >= 1)
                        {
                            line = line.Remove(i + 1 + j, 1);
                            strength -= 1;
                        }
                        if (line[i + 1 + j] == '>')
                        {
                            switch (line[i + 1 + j + 1])
                            {
                                case '0':
                                    strength += 0;
                                    break;
                                case '1':
                                    strength += 1;
                                    break;
                                case '2':
                                    strength += 2;
                                    break;
                                case '3':
                                    strength += 3;
                                    break;
                                case '4':
                                    strength += 4;
                                    break;
                                case '5':
                                    strength += 5;
                                    break;
                                case '6':
                                    strength += 6;
                                    break;
                                case '7':
                                    strength += 7;
                                    break;
                                case '8':
                                    strength += 8;
                                    break;
                                case '9':
                                    strength += 9;
                                    break;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(line);
        }
    }
}
