namespace SingletonDemo
{
    using System;
    using System.Collections.Generic;

    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        private static SingletonDataContainer instance = new SingletonDataContainer();

        public static SingletonDataContainer Instance => instance;

        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            // var elements = File.ReadAllLines({filePath});
            // I will insert some magic strings here for test purposes
            var elements = new List<string>
            {
                "Washington, D.C.",
                "633427",
                "London",
                "8908081"
            };

            for (int i = 0; i < elements.Count; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
