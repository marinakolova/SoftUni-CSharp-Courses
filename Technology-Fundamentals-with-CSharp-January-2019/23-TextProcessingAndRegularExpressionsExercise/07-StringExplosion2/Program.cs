using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main()
        {
            string field = Console.ReadLine();
            int bomb = 0;
            for (int i = 0; i < field.Length; i++)
            {
                if (bomb > 0 && field[i] != '>')
                {
                    field = field.Remove(i, 1); // Remove char on this index
                    bomb--; // One bomb is used
                    i--; // after remove next char is moved 1 position, so return counter i to this char, decreasing i by 1  
                }
                else if (field[i] == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString()); // takes the digit after '>' - bomb strength and add to bomb
                }
            }
            Console.WriteLine(field);
        }
    }
}