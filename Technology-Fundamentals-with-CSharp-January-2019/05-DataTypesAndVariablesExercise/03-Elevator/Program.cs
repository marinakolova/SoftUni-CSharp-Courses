using System;

namespace _03_Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = 0;

            courses = numOfPeople / capacity;

            if (numOfPeople % capacity != 0)
            {
                courses++;
            }

            Console.WriteLine(courses);
        }
    }
}
