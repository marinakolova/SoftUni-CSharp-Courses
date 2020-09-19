using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<int>>> army = new Dictionary<string, Dictionary<string, List<int>>>();

            while (count-- > 0)
            {
                var input = Console.ReadLine();

                var data = input.Split();
                var type = data[0];
                var name = data[1];
                var damage = data[2] == "null" ? 45 : int.Parse(data[2]);
                var health = data[3] == "null" ? 250 : int.Parse(data[3]);
                var armor = data[4] == "null" ? 10 : int.Parse(data[4]);

                if (!army.ContainsKey(type))
                {
                    army.Add(type, new Dictionary<string, List<int>>());
                }

                army[type][name] = new List<int>();

                army[type][name].Add(damage);
                army[type][name].Add(health);
                army[type][name].Add(armor);
            }

            foreach (var type in army)
            {
                double avDamage = 1.00 * (type.Value.Values.Select(x => x[0]).Sum()) / army[type.Key].Count;
                double avHealth = 1.00 * (type.Value.Values.Select(x => x[1]).Sum()) / army[type.Key].Count;
                double avArmor = 1.00 * (type.Value.Values.Select(x => x[2]).Sum()) / army[type.Key].Count;

                Console.WriteLine($"{type.Key}::({avDamage:F2}/{avHealth:F2}/{avArmor:F2})");


                foreach (var dragon in type.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}