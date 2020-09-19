using System;
using CustomTestingFramework.TestRunner;

namespace MyProgram
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var runner = new Runner();

            var result = runner.Run(@"..\..\..\..\CustomTestingFramework.Tests\bin\Debug\netcoreapp2.2\CustomTestingFramework.Tests.dll");

            foreach (var info in result)
            {
                Console.WriteLine(info);
            }
        }
    }
}
