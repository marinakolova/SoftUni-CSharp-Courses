using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            int totalDays = DateModifier.CalcDaysBetweenDates(firstDate, secondDate);
            Console.WriteLine(Math.Abs(totalDays));
        }
    }
}
