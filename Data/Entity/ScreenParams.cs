using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public abstract class ScreenParams
    {
        public static int Width { get; internal set; }
        public static int Height { get; internal set; }
        public static double CircleRadius { get; internal set; }
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
