/// https://www.codewars.com/kata/53f1015fa9fe02cbda00111a

using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_08._02_Color_Ghost
{
    public class Ghost
    {
        public string color { get; }

        static readonly List<string> Colors = new() { "white", "yellow", "purple", "red" };
        static Random RandomGenerator = new Random();

        public Ghost()
        {
            int index = RandomGenerator.Next(Colors.Count);
            this.color = Colors[index];
        }

        public string GetColor()
        {
            return this.color;
        }
    }
}
