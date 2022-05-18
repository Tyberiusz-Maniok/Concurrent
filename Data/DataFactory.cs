using Data.Dao;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class DataFactory
    {
        public static IMovableRepository getCircleRepository(int width, int height, double radius, double speed)
        {
            ScreenParams.Width = width;
            ScreenParams.Height = height;
            ScreenParams.CircleRadius = radius;
            ScreenParams.Speed = speed;
            return new CircleRepository();
        }

        public static MovableEntity CreateCicle(double xPos, double yPos, double xDirection, double yDirection)
        {
            return new CircleEntity(xPos, yPos, xDirection, yDirection);
        }
    }
}
