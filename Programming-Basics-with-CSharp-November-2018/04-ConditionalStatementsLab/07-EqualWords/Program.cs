using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EqualWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string word1 = Console.ReadLine().ToLower();
            string word2 = Console.ReadLine().ToLower();

            if (word1 == word2)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
