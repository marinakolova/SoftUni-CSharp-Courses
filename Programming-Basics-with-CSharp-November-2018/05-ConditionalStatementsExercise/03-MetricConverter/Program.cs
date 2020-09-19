using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string med1 = Console.ReadLine();
            string med2 = Console.ReadLine();

            double result = 0;

            if (med1 == "m")
            {
                if (med2 == "m")
                    result = num;
                else if (med2 == "mm")
                    result = num * 1000;
                else if (med2 == "cm")
                    result = num * 100;
                else if (med2 == "mi")
                    result = num * 0.000621371192;
                else if (med2 == "in")
                    result = num * 39.3700787;
                else if (med2 == "km")
                    result = num * 0.001;
                else if (med2 == "ft")
                    result = num * 3.2808399;
                else if (med2 == "yd")
                    result = num * 1.0936133;
            }

            else if (med1 == "mm")
            {
                if (med2 == "m")
                    result = num / 1000;
                else if (med2 == "mm")
                    result = num;
                else if (med2 == "cm")
                    result = (num / 1000) * 100;
                else if (med2 == "mi")
                    result = (num / 1000) * 0.000621371192;
                else if (med2 == "in")
                    result = (num / 1000) * 39.3700787;
                else if (med2 == "km")
                    result = (num / 1000) * 0.001;
                else if (med2 == "ft")
                    result = (num / 1000) * 3.2808399;
                else if (med2 == "yd")
                    result = (num / 1000) * 1.0936133;
            }

            else if (med1 == "cm")
            {
                if (med2 == "m")
                    result = num / 100;
                else if (med2 == "mm")
                    result = (num / 100) * 1000;
                else if (med2 == "cm")
                    result = num;
                else if (med2 == "mi")
                    result = (num / 100) * 0.000621371192;
                else if (med2 == "in")
                    result = (num / 100) * 39.3700787;
                else if (med2 == "km")
                    result = (num / 100) * 0.001;
                else if (med2 == "ft")
                    result = (num / 100) * 3.2808399;
                else if (med2 == "yd")
                    result = (num / 100) * 1.0936133;
            }

            else if (med1 == "mi")
            {
                if (med2 == "m")
                    result = num / 0.000621371192;
                else if (med2 == "mm")
                    result = (num / 0.000621371192) * 1000;
                else if (med2 == "cm")
                    result = (num / 0.000621371192) * 100;
                else if (med2 == "mi")
                    result = num;
                else if (med2 == "in")
                    result = (num / 0.000621371192) * 39.3700787;
                else if (med2 == "km")
                    result = (num / 0.000621371192) * 0.001;
                else if (med2 == "ft")
                    result = (num / 0.000621371192) * 3.2808399;
                else if (med2 == "yd")
                    result = (num / 0.000621371192) * 1.0936133;
            }

            else if (med1 == "in")
            {
                if (med2 == "m")
                    result = num / 39.3700787;
                else if (med2 == "mm")
                    result = (num / 39.3700787) * 1000;
                else if (med2 == "cm")
                    result = (num / 39.3700787) * 100;
                else if (med2 == "mi")
                    result = (num / 39.3700787) * 0.000621371192;
                else if (med2 == "in")
                    result = num;
                else if (med2 == "km")
                    result = (num / 39.3700787) * 0.001;
                else if (med2 == "ft")
                    result = (num / 39.3700787) * 3.2808399;
                else if (med2 == "yd")
                    result = (num / 39.3700787) * 1.0936133;
            }

            else if (med1 == "km")
            {
                if (med2 == "m")
                    result = num / 0.001;
                else if (med2 == "mm")
                    result = (num / 0.001) * 1000;
                else if (med2 == "cm")
                    result = (num / 0.001) * 100;
                else if (med2 == "mi")
                    result = (num / 0.001) * 0.000621371192;
                else if (med2 == "in")
                    result = (num / 0.001) * 39.3700787;
                else if (med2 == "km")
                    result = num;
                else if (med2 == "ft")
                    result = (num / 0.001) * 3.2808399;
                else if (med2 == "yd")
                    result = (num / 0.001) * 1.0936133;
            }

            else if (med1 == "ft")
            {
                if (med2 == "m")
                    result = num / 3.2808399;
                else if (med2 == "mm")
                    result = (num / 3.2808399) * 1000;
                else if (med2 == "cm")
                    result = (num / 3.2808399) * 100;
                else if (med2 == "mi")
                    result = (num / 3.2808399) * 0.000621371192;
                else if (med2 == "in")
                    result = (num / 3.2808399) * 39.3700787;
                else if (med2 == "km")
                    result = (num / 3.2808399) * 0.001;
                else if (med2 == "ft")
                    result = num;
                else if (med2 == "yd")
                    result = (num / 3.2808399) * 1.0936133;
            }

            else if (med1 == "yd")
            {
                if (med2 == "m")
                    result = num / 1.0936133;
                else if (med2 == "mm")
                    result = (num / 1.0936133) * 1000;
                else if (med2 == "cm")
                    result = (num / 1.0936133) * 100;
                else if (med2 == "mi")
                    result = (num / 1.0936133) * 0.000621371192;
                else if (med2 == "in")
                    result = (num / 1.0936133) * 39.3700787;
                else if (med2 == "km")
                    result = (num / 1.0936133) * 0.001;
                else if (med2 == "ft")
                    result = (num / 1.0936133) * 3.2808399;
                else if (med2 == "yd")
                    result = (num / 1.0936133) * 1.0936133;
            }

            Console.WriteLine($"{result:F8}");
        }
    }
}
