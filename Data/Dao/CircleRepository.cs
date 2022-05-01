using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dao
{
    internal class CircleRepository : MovableRepository
    {
        private List<MovableEntity> circles;
        private Random random = new Random();

        public CircleRepository()
        {
            this.circles = new List<MovableEntity>();
        }
        public void Create(int count, int width, int height)
        {
            for (int i = 0; i < count; i++)
            {
                this.circles.Add(new CircleEntity(ClampPos(random.NextDouble() * width, width - CircleEntity.Radius, CircleEntity.Radius),
                    ClampPos(random.NextDouble() * height, height - CircleEntity.Radius, CircleEntity.Radius), 0, 0));
            }
        }

        public MovableEntity Get(int id)
        {
            return this.circles.Find(circle => circle.Id == id);
        }

        public List<MovableEntity> GetAll()
        {
            return this.circles;
        }

        public void UpdateAll(List<MovableEntity> items)
        {
            this.circles = items;
        }

        private double ClampPos(double pos, double max, double min)
        {
            if (pos > max)
            {
                pos = max;
            }
            if (pos < min)
            {
                pos = min;
            }
            return pos;
        }
    }
}
