using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Boxes
{
    public class Box
    {
        public int Width { get; set; }

        public int Depth { get; set; }

        public int Height { get; set; }
    }

    public class Program
    {        
        public static void Main(string[] args)
        {
            var boxesCount = int.Parse(Console.ReadLine());

            var boxes = new Box[boxesCount];

            for (int i = 0; i < boxesCount; i++)
            {
                var boxData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var width = boxData[0];
                var depth = boxData[1];
                var height = boxData[2];

                var box = new Box
                {
                    Width = width,
                    Depth = depth,
                    Height = height
                };

                boxes[i] = box;
            }

            var len = new int[boxes.Length];
            var prevs = new int[boxes.Length];

            var bestLen = 0;
            var lastIndex = 0;

            for (int current = 0; current < boxes.Length; current++)
            {
                len[current] = 1;
                prevs[current] = -1;

                var currBox = boxes[current];

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevBox = boxes[prev];

                    if (prevBox.Width < currBox.Width &&
                        prevBox.Depth < currBox.Depth &&
                        prevBox.Height < currBox.Height &&
                        len[prev] + 1 >= len[current])
                    {
                        len[current] = len[prev] + 1;
                        prevs[current] = prev;
                    }
                }

                if (len[current] > bestLen)
                {
                    bestLen = len[current];
                    lastIndex = current;
                }
            }

            var stack = new Stack<Box>();

            while (lastIndex != -1)
            {
                stack.Push(boxes[lastIndex]);
                lastIndex = prevs[lastIndex];
            }

            foreach (var box in stack)
            {
                Console.WriteLine($"{box.Width} {box.Depth} {box.Height}");
            }
        }
    }
}
