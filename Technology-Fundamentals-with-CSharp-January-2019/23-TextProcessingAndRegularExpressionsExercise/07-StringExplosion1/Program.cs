using System;
using System.Text;

namespace _07_StringExplosion1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLine = new StringBuilder(Console.ReadLine());
            int remainingPower = 0;
            for (int i = 0; i < inputLine.Length; i++)
            {
                var currentChar = inputLine[i];
                if (currentChar == '>')
                {
                    int power = int.Parse(inputLine[i + 1].ToString()) + remainingPower;
                    var subSeq = inputLine.ToString().Substring(i + 1, power);
                    if (!subSeq.Contains('>'))
                    {
                        inputLine.Remove(i + 1, power);
                        remainingPower = 0;
                    }
                    else
                    {
                        int removalCount = 0;
                        int indexOfMark = subSeq.IndexOf('>');
                        for (int j = 0; j < indexOfMark; j++)
                        {
                            removalCount++;
                        }
                        inputLine.Remove(i + 1, removalCount);
                        remainingPower = power - removalCount;
                    }
                }
            }
            Console.WriteLine(inputLine);
        }
    }
}
