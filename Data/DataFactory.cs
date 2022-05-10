using Data.Dao;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class DataFactory
    {
        public static IMovableRepository getCircleRepository(int width, int height, double radius)
        {
            ScreenParams.Width = width;
            ScreenParams.Height = height;
            ScreenParams.CircleRadius = radius;
            return new CircleRepository();
        }
    }
}
