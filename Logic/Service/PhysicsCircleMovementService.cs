using Data;
using Data.Dao;
using Data.Entity;
using Logic.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service
{
    internal class PhysicsCircleMovementService : ICircleMovementService
    {
        private IMovableRepository circleRepository;
        private List<MovableEntity> Circles;

        public PhysicsCircleMovementService(IMovableRepository circleRepository)
        {
            this.circleRepository = circleRepository;
            Circles = new List<MovableEntity>();
        }

        public void calcPosBatch()
        {
            List<Task> tasks = new List<Task>();
            foreach (MovableEntity circle in Circles)
            {
                tasks.Add(new Task(() => circle.Move()));
            }
            foreach (Task task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks.ToArray());
        }

        public List<MovableDto> GetCircles()
        {
            throw new NotImplementedException();
        }

        public List<MovableDto> InitCircles(int count)
        {
            circleRepository.Create(count);
            return null;
        }

        private List<MovableDto> EntityToDto(List<MovableEntity> entities)
        {
            List<MovableDto> result = new List<MovableDto>();
            foreach (MovableEntity entity in entities)
            {
                result.Add(new CircleDto(entity));
            }
            return result;
        }

        private void ResolveCollision(ref MovableEntity circle)
        {
            ResolveWallCollision(circle);
            foreach (MovableEntity c in Circles)
            {
                if (!c.Equals(circle))
                {
                    ResolveCircleCollision(circle, c);
                }
            }
        }

        private void ResolveWallCollision(MovableEntity circle)
        {
            try
            {
                circle.TryLock();
                double newXDir = circle.XDirection;
                double newYDir = circle.YDirection;
                if (circle.XPos < ScreenParams.LowerBound())
                {
                    newXDir *= -1;
                }
                if (circle.YPos < ScreenParams.LowerBound())
                {
                    newYDir *= -1;
                }
                if (circle.XPos > ScreenParams.UpperXBound())
                {
                    newXDir *= -1;
                }
                if (circle.YPos > ScreenParams.UpperYBound())
                {
                    newYDir *= -1;
                }
                circle.Update(newXDir, newYDir);
            }
            finally
            {
                circle.ReleaseLock();
            }
        }

        private void ResolveCircleCollision(MovableEntity circle1, MovableEntity circle2)
        {
            try
            {
                if (circle1.Id < circle2.Id)
                {
                    circle1.TryLock();
                    circle2.TryLock();
                }
                else
                {
                    circle2.TryLock();
                    circle1.TryLock();
                }
                double distance = Distance(circle1, circle2);
                bool willCollide = false;
                if (distance < ScreenParams.CircleRadius * 2)
                {
                    willCollide = true;
                }
                if (willCollide)
                {
                    double xDir = (circle2.XPos - circle1.XPos) / distance;
                    double yDir = (circle2.YPos - circle1.YPos) / distance;
                    double xPerpendicular = -yDir;
                    double yPerpendicular = xDir;
                    double response1 = circle1.XDirection * xPerpendicular + circle1.YDirection * yPerpendicular;
                    double response2 = circle2.XDirection * xPerpendicular + circle2.YDirection * yPerpendicular;
                    circle1.Update(xPerpendicular * response1, yPerpendicular * response1);
                    circle2.Update(xPerpendicular * response2, yPerpendicular * response2);
                }
            }
            finally
            {
                circle2.ReleaseLock();
                circle1.ReleaseLock();
            }
        }
        private double Distance(MovableEntity circle1, MovableEntity circle2)
        {
            double xDist = circle1.XPos - circle2.XPos;
            double yDist = circle1.YPos - circle2.YPos;
            return Math.Sqrt(xDist * xDist + yDist * yDist);
        }
    }
}
