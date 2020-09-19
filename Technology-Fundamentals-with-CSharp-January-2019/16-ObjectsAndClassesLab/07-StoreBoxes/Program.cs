using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] data = input.Split();

                Box newBox = new Box();

                newBox.SerialNumber = data[0];
                newBox.ItemName = data[1];
                newBox.ItemQuantity = int.Parse(data[2]);
                newBox.ItemPrice = decimal.Parse(data[3]);
                newBox.BoxPirce = newBox.ItemQuantity * newBox.ItemPrice;

                boxes.Add(newBox);
            }

            var orderedBoxes = boxes.OrderBy(x => x.BoxPirce).ToList();
            orderedBoxes.Reverse();

            foreach (var box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.ItemName} - ${box.ItemPrice:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPirce:F2}");
            }
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal BoxPirce { get; set; }
    }
}
