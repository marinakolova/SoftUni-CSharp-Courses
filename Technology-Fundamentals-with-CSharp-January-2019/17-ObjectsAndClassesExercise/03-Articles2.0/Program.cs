using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Article article = new Article();
                string[] input = Console.ReadLine().Split(", ").ToArray();

                article.Title = input[0];
                article.Content = input[1];
                article.Author = input[2];

                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            switch (criteria)
            {
                case "title":
                    articles = articles.OrderBy(x => x.Title).ToList();
                    break;

                case "content":
                    articles = articles.OrderBy(x => x.Content).ToList();
                    break;

                case "author":
                    articles = articles.OrderBy(x => x.Author).ToList();
                    break;
            }

            foreach (var article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
