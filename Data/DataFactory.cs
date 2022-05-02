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
            return new CircleRepository(new ScreenParams(width, height, radius));
        }
    }
}
