using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarceRover
{
    public class Point
    {
        public static int Increament(int point, int steps)
        {
            return point + steps;
        }

        public static int Decrement(int point, int steps)
        {
            return point - steps;
        }
    }
}
