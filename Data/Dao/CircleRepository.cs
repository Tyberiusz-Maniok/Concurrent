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
        private ScreenParams rect;

        public CircleRepository(ScreenParams rect)
        {
            this.circles = new List<MovableEntity>();
            this.rect = rect;
        }
        public void Create(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.circles.Add(new CircleEntity(
                    ClampXPos(random.NextDouble() * rect.Width), ClampYPos(random.NextDouble() * rect.Height), 0, 0));
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
            if (pos > rect.UpperXBound())
            {
                pos = rect.UpperXBound();
            }
            if (pos < rect.LowerBound())
            {
                pos = rect.LowerBound();
            }
            return pos;
        }

        private double ClampYPos(double pos)
        {
            if (pos > rect.UpperYBound())
            {
                pos = rect.UpperYBound();
            }
            if (pos < rect.LowerBound())
            {
                pos = rect.LowerBound();
            }
            return pos;
        }
    }
}
