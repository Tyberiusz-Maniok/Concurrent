using Data;
using Data.Dao;
using Data.Entity;
using Logic.Collections;
using Logic.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic.Service
{
    internal class PhysicsCircleMovementService : ICircleMovementService
    {
        private IMovableRepository circleRepository;
        private LockableList<MovableEntity> Circles;
        private int interval = 20000;
        private Stopwatch stopwatch = new Stopwatch();
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        //private CancellationToken cancellationToken = new CancellationTokenSource().Token;

        public PhysicsCircleMovementService(IMovableRepository circleRepository)
        {
            this.circleRepository = circleRepository;
            Circles = new LockableList<MovableEntity>();
        }

        public void calcPosBatch()
        {
        }

        public List<MovableDto> GetCircles()
        {
            return EntityToDto(Circles);
        }

        public List<MovableDto> InitCircles(int count)
        {
            List<MovableEntity> crcls = circleRepository.Create(count, HandleCircleEvent);
            foreach(MovableEntity circle in Circles)
            {
                circle.StopMovement();
            }
            Circles.Clear();
            foreach(MovableEntity circle in crcls)
            {
                Circles.Add(circle);
            }
            foreach(MovableEntity circle in Circles)
            {
                circle.StartMovement(tokenSource.Token);
            }
            return EntityToDto(Circles);
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

        private void HandleCircleEvent(object sender, PropertyChangedEventArgs evt)
        {
            MovableEntity circle = (MovableEntity)sender;
            ResolveCollision(circle);
            //Task col = new Task(() => ResolveCollision(circle));
            //col.Start();
            //col.Wait();
        }

        private void ResolveCollision(MovableEntity circle)
        {
            ResolveWallCollision(circle);
            try
            {
                //Circles.TryLock();
                foreach (MovableEntity c in Circles)
                {
                    if (!c.Equals(circle))
                    {
                        ResolveCircleCollision(circle, c);
                    }
                }
            }
            finally
            {
                //Circles.ReleaseLock();
            }

        }

        private void ResolveWallCollision(MovableEntity circle)
        {
            try
            {
                //circle.TryLock();
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
                circle.Update(newXDir, newYDir, true);
            }
            finally
            {
                //circle.ReleaseLock();
            }
        }

        private void ResolveCircleCollision(MovableEntity circle1, MovableEntity circle2)
        {
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
                    //circle1.Move(-0.5f, false);
                    //circle2.Move(-0.5f, false);
                    circle1.Update(xPerpendicular * response1, yPerpendicular * response1, true);
                    circle2.Update(xPerpendicular * response2, yPerpendicular * response2, true);
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
