using System;

namespace _03_Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var customStack = new CustomStack<string>();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var partsOfCommand = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                switch (partsOfCommand[0])
                {
                    case "Push":
                        var elements = new string[partsOfCommand.Length - 1];
                        for (int i = 1; i < partsOfCommand.Length; i++)
                        {
                            elements[i - 1] = partsOfCommand[i];
                        }
                        customStack.Push(elements);
                        break;

                    case "Pop":
                        customStack.Pop();
                        break;
                }
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
