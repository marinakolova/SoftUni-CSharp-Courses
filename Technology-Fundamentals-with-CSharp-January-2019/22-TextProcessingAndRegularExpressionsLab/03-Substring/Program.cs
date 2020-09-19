using System;
using System.Text;

namespace _03_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            while (secondString.Contains(firstString, StringComparison.InvariantCultureIgnoreCase))
            {
                int index = secondString.IndexOf(firstString, StringComparison.InvariantCultureIgnoreCase);
                secondString = secondString.Remove(index, firstString.Length);
            }

            Console.WriteLine(secondString);
        }
    }
}
