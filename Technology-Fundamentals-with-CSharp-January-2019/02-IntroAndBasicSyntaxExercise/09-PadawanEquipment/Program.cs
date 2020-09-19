using System;

namespace _09_PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double lightsabersCount = Math.Ceiling(studentsCount + 0.10 * studentsCount);
            double robesCount = studentsCount;
            double beltsCount = studentsCount - studentsCount / 6;

            double totalPrice = lightsabersCount * lightsabersPrice + robesCount * robesPrice + beltsCount * beltsPrice;
            double moneyNeeded = totalPrice - money;

            if (totalPrice <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }

            else
            {
                Console.WriteLine($"Ivan Cho will need {moneyNeeded:F2}lv more.");
            }

        }
    }
}
