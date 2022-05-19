using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    internal static class ScreenParams
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static double CircleRadius { get; set; }
        public static double Speed { get; internal set; }

        public static double UpperXBound()
        {
            return Width - CircleRadius;
        }

        public static double UpperYBound()
        {
            return Height - CircleRadius;
        }

        public static double LowerBound()
        {
            return CircleRadius;
        }

    }
}
