namespace SingletonDemo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            // We can call the Instance property as many times as we want, but our object is going to be instantiated only once
            var db = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("Washington, D.C."));
            Console.WriteLine(db2.GetPopulation("London"));
        }
    }
}
