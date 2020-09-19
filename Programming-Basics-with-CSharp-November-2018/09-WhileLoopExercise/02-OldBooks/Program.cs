using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int capacity = int.Parse(Console.ReadLine());

            int bookCount = 0;
            bool foundTheBook = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == book)
                {
                    foundTheBook = true;
                    break;
                }

                bookCount++;

                if (bookCount == capacity)
                {
                    break;
                }
            }

            if (foundTheBook)
            {
                Console.WriteLine($"You checked {bookCount} books and found it.");
            }

            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {bookCount} books.");
            }
        }
    }
}
