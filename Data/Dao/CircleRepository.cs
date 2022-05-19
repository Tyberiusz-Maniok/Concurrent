using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dao
{
    internal class CircleRepository : IMovableRepository
    {
        private Random random = new Random();

        List<MovableEntity> IMovableRepository.Create(int count)
        {
            List<MovableEntity> circles = new List<MovableEntity>();
            for (int i = 0; i < count; i++)
            {
                double xDir = random.NextDouble();
                circles.Add(new CircleEntity(
                    ClampXPos(random.NextDouble() * ScreenParams.Width), ClampYPos(random.NextDouble() * ScreenParams.Height),
                        xDir, Math.Sqrt(1 - xDir)));
            }
            return circles;
        }

        private double ClampXPos(double pos)
        {
            if (pos > ScreenParams.UpperXBound())
            {
                pos = ScreenParams.UpperXBound();
            }
            if (pos < ScreenParams.LowerBound())
            {
                pos = ScreenParams.LowerBound();
            }
            return pos;
        }

        private double ClampYPos(double pos)
        {
            if (pos > ScreenParams.UpperYBound())
            {
                pos = ScreenParams.UpperYBound();
            }
            if (pos < ScreenParams.LowerBound())
            {
                pos = ScreenParams.LowerBound();
            }
            return pos;
        }
    }
}
