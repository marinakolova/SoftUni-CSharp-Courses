using System;
using System.Collections.Generic;
using System.Text;

namespace _02_ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputKeys = Console.ReadLine().Split("&");
            var validKeys = new List<string>();
            var outputKeys = new List<StringBuilder>();

            foreach (var key in inputKeys)
            {
                bool isValid = true;

                for (int i = 0; i < key.Length; i++)
                {
                    if (!char.IsLetterOrDigit(key[i]))
                    {
                        isValid = false;
                    }
                }
                if (key.Length != 16 && key.Length != 25)
                {
                    isValid = false;
                }

                if (isValid)
                {
                    validKeys.Add(key);
                }
            }

            foreach (var key in validKeys)
            {
                var keyToAdd = new StringBuilder(key);

                if (key.Length == 16)
                {
                    keyToAdd.Insert(4, "-");
                    keyToAdd.Insert(9, "-");
                    keyToAdd.Insert(14, "-");
                }
                else if (key.Length == 25)
                {
                    keyToAdd.Insert(5, "-");
                    keyToAdd.Insert(11, "-");
                    keyToAdd.Insert(17, "-");
                    keyToAdd.Insert(23, "-");
                }

                for (int i = 0; i < keyToAdd.Length; i++)
                {
                    if (char.IsLetter(keyToAdd[i]) && char.IsLower(keyToAdd[i]))
                    {
                        keyToAdd[i] = char.ToUpper(keyToAdd[i]);
                    }

                    else if (char.IsDigit(keyToAdd[i]))
                    {
                        var currDigit = int.Parse(keyToAdd[i].ToString());
                        var newDigit = 9 - currDigit;

                        keyToAdd[i] = char.Parse(newDigit.ToString());
                    }
                }

                outputKeys.Add(keyToAdd);
            }

            Console.WriteLine(string.Join(", ", outputKeys));
        }
    }
}
