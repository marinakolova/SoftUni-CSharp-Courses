﻿using System;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int countOfAppenders = int.Parse(Console.ReadLine());
            var controller = new Controller();
            controller.Act(countOfAppenders);
        }
    }
}
