using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    internal class ScreenParams
    {
        public int Width { get; }
        public int Height { get; }
        public double CircleRadius { get; }

        public ScreenParams(int width, int height, double circleRadius)
        {
            Width = width;
            Height = height;
            CircleRadius = circleRadius;
        }

        public double UpperXBound()
        {
            return Width - CircleRadius;
        }

        public double UpperYBound()
        {
            return Height - CircleRadius;
        }

        public double LowerBound()
        {
            return CircleRadius;
        }

    }
}
