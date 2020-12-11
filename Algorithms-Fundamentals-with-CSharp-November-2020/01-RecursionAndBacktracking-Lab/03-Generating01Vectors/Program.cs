using System;

namespace _03_Generating01Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            Gen01(arr, 0);
        }

        private static void Gen01(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;

                Gen01(arr, index + 1);                
            }            
        }
    }
}
