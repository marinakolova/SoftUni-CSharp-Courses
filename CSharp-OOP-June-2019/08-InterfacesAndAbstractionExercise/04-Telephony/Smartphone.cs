using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public void Browse(string[] sites)
        {
            foreach (var url in sites)
            {
                if (url != " ")
                {
                    bool isValid = true;
                    foreach (var ch in url)
                    {
                        if (char.IsDigit(ch))
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine($"Browsing: {url}!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid URL!");
                    }
                }
            }
        }

        public void Call(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                if (number != " ")
                {
                    bool isValid = true;
                    foreach (var ch in number)
                    {
                        if (!char.IsDigit(ch))
                        {
                            isValid = false;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine($"Calling... {number}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid number!");
                    }
                }
            }
        }
    }
}
