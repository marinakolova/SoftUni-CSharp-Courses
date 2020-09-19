using System;
using System.Collections.Generic;

namespace _05_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            var title = Console.ReadLine();
            var content = Console.ReadLine();
            var comments = new List<string>();

            while (true)
            {
                var comment = Console.ReadLine();
                if (comment == "end of comments")
                {
                    break;
                }
                comments.Add(comment);
            }

            Console.WriteLine("<h1>");
            Console.WriteLine($"\t{title}");
            Console.WriteLine("</h1>");

            Console.WriteLine("<article>");
            Console.WriteLine($"\t{content}");
            Console.WriteLine("</article>");

            foreach (var comment in comments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"\t{comment}");
                Console.WriteLine("</div>");
            }
        }
    }
}
