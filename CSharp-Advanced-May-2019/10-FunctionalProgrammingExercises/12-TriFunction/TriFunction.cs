using System;

namespace _12_TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                int sum = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }

                if (sum >= n)
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
