using System;
using System.Collections.Generic;

namespace _09_CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var firstLine = new List<int>();
            var secondLine = new List<int>();
            var thirdLine = new List<int>();

            var fourthLine = new List<string>();
            var fifthLine = new List<string>();

            var elementsToAdd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in elementsToAdd)
            {
                firstLine.Add(addCollection.Add(element));
                secondLine.Add(addRemoveCollection.Add(element));
                thirdLine.Add(myList.Add(element));
            }

            var removeOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeOperations; i++)
            {
                fourthLine.Add(addRemoveCollection.Remove());
                fifthLine.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", firstLine));
            Console.WriteLine(string.Join(" ", secondLine));
            Console.WriteLine(string.Join(" ", thirdLine));
            Console.WriteLine(string.Join(" ", fourthLine));
            Console.WriteLine(string.Join(" ", fifthLine));
        }
    }
}
