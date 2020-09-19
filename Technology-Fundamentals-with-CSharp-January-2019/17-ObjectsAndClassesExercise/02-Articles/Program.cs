using System;
using System.Linq;

namespace _02_Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            Article article = new Article();
            string[] input = Console.ReadLine().Split(", ").ToArray();

            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ").ToArray();

                switch (command[0])
                {
                    case "Edit":
                        article.Content = command[1];
                        break;

                    case "ChangeAuthor":
                        article.Author = command[1];
                        break;

                    case "Rename":
                        article.Title = command[1];
                        break;
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
