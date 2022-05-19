using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dao
{
    internal class CircleRepository : IMovableRepository
    {
        private List<MovableEntity> circles;
        private Random random = new Random();

        public CircleRepository()
        {
            this.circles = new List<MovableEntity>();
        }
        public List<MovableEntity> Create(int count)
        {
            for (int i = 0; i < count; i++)
            {
                double xDir = random.NextDouble();
                this.circles.Add(new CircleEntity(
                    ClampXPos(random.NextDouble() * ScreenParams.Width), ClampYPos(random.NextDouble() * ScreenParams.Height),
                        xDir, Math.Sqrt(1 - xDir)));
            }
            return this.circles;
        }

        public MovableEntity Get(int id)
        {
            return this.circles.Find(circle => circle.Id == id);
        }

        public List<MovableEntity> GetAll()
        {
            return this.circles;
        }

        public void Update(int id, MovableEntity entity)
        {
            this.circles.Remove(Get(id));
            this.circles.Add(entity);
        }

        public void UpdateAll(List<MovableEntity> items)
        {
            this.circles = items;
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
