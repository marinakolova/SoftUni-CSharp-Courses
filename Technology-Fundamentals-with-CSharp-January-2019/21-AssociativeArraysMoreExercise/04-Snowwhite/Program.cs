using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Hat> hats = new HashSet<Hat>();
            List<Dwarf> dwarfs = new List<Dwarf>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] data = input.Split(new char[] { ' ', '<', ':', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string hat = data[1];
                long physics = long.Parse(data[2]);


                if (dwarfs.Select(x => x.Name).Contains(name) && dwarfs.Where(x => x.Name == name).Select(x => x.Hat.Name).Contains(hat))
                {
                    Dwarf repeatedDwarf = dwarfs.Single(x => x.Name == name && x.Hat.Name == hat);
                    repeatedDwarf.Physics = repeatedDwarf.Physics < physics ? physics : repeatedDwarf.Physics;
                }
                else
                {
                    if (hats.Select(x => x.Name).Contains(hat))
                    {
                        hats.Single(x => x.Name == hat).Count++;
                    }
                    else
                    {
                        hats.Add(new Hat(hat));
                    }
                    dwarfs.Add(new Dwarf(name, hats.Single(x => x.Name == hat), physics));
                }
            }

            foreach (Dwarf dwarf in dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => x.Hat.Count))
            {
                Console.WriteLine($"({dwarf.Hat.Name}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }

    class Dwarf
    {
        public Hat Hat { get; private set; }
        public string Name { get; private set; }
        public long Physics { get; set; }

        public Dwarf(string name, Hat hat, long physics)
        {
            this.Hat = hat;
            this.Name = name;
            this.Physics = physics;
        }
    }

    class Hat
    {
        public string Name { get; private set; }
        public long Count { get; set; }

        public Hat(string name)
        {
            this.Name = name;
            this.Count = 0;
        }
    }
}