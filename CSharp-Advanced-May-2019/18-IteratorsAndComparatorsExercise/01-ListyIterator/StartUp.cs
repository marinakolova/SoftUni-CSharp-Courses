using System;

namespace _01_ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var createCommand = Console.ReadLine().Split();
            var initialCollection = new string[createCommand.Length - 1];

            for (int i = 1; i < createCommand.Length; i++)
            {
                initialCollection[i - 1] = createCommand[i];
            }

            var listyIterator = new ListyIterator<string>(initialCollection);

            var nextCommand = Console.ReadLine();

            while (nextCommand != "END")
            {
                switch (nextCommand)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "Print":
                        listyIterator.Print();
                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }

                nextCommand = Console.ReadLine();
            }
        }
    }
}
