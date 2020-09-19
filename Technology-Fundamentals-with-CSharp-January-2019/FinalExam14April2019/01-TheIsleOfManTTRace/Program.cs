using System;
using System.Text;

namespace _01_TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool nameIsValid = false;
                bool geohashIsValid = false;

                var input = Console.ReadLine();

                if (input.Contains("="))
                {
                    var partsOfInput = input.Split("=");
                    var name = partsOfInput[0];
                    var geohash = partsOfInput[1];

                    if (name[0] == '#'
                        || name[0] == '$'
                        || name[0] == '%'
                        || name[0] == '*'
                        || name[0] == '&')
                    {
                        var charAtTheBeginning = name[0];
                        var charAtTheEnd = name[name.Length - 1];

                        if (charAtTheBeginning == charAtTheEnd)
                        {
                            bool onlyLetters = true;

                            for (int i = 0; i < name.Length; i++)
                            {
                                if (i != 0 && i != name.Length - 1)
                                {
                                    if (!char.IsLetter(name[i]))
                                    {
                                        onlyLetters = false;
                                    }
                                }
                            }

                            if (onlyLetters)
                            {
                                nameIsValid = true;
                            }
                        }
                    }

                    if (nameIsValid)
                    {
                        var nameToPrint = new StringBuilder();
                        for (int i = 0; i < name.Length; i++)
                        {
                            var currChar = name[i];
                            if (i != 0 && i != name.Length - 1)
                            {
                                nameToPrint.Append(currChar);
                            }
                        }

                        if (geohash.Contains("!!"))
                        { 
                            var partsOfGeohash = geohash.Split("!!", 2);
                            var lengthOfGeohash = int.Parse(partsOfGeohash[0]);
                            var encryptedGeohash = partsOfGeohash[1];

                            if (lengthOfGeohash == encryptedGeohash.Length)
                            {
                                geohashIsValid = true;
                            }

                            if (geohashIsValid)
                            {
                                var decryptedGeohash = new StringBuilder();

                                for (int i = 0; i < encryptedGeohash.Length; i++)
                                {
                                    var currChar = encryptedGeohash[i];
                                    var newChar = (char)(currChar + lengthOfGeohash);

                                    decryptedGeohash.Append(newChar);
                                }

                                Console.WriteLine($"Coordinates found! {nameToPrint} -> {decryptedGeohash}");
                                break;
                            }
                        }
                    }
                }

                Console.WriteLine("Nothing found!");
            }
        }
    }
}
