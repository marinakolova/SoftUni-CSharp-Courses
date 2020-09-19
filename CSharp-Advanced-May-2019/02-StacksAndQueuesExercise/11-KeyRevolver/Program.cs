using System;
using System.Collections.Generic;
using System.Linq;

namespace _11_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            var bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            var locks = new Queue<int>();
            var bullets = new Stack<int>();

            foreach (var item in locksInput)
            {
                locks.Enqueue(item);
            }

            foreach (var item in bulletsInput)
            {
                bullets.Push(item);
            }

            var shootedBullets = 0;
            var totalBulletsPrice = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                var currBullet = bullets.Peek();
                var currLock = locks.Peek();

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                }

                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                }

                shootedBullets++;
                totalBulletsPrice += bulletPrice;

                if (shootedBullets == barrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shootedBullets = 0;
                }
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - totalBulletsPrice}");
            }
        }
    }
}
