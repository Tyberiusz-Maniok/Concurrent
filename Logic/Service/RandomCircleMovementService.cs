using Logic.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service
{
    public class RandomCircleMovementService : ICircleMovementService
    {
        private IPositionGenerator positionGenerator;
        private double speed;
        private static readonly double tolerance = 0.01;

        public RandomCircleMovementService(IPositionGenerator positionGenerator, double speed)
        {
            this.positionGenerator = positionGenerator;
            this.speed = speed;
        }

        public MovableDto calcPos(MovableDto circle)
        {
            MovableDto updated = MoveCircle(circle);
            if (updated.closeToTarget(tolerance))
            {
                updated = positionGenerator.GeneratePos(updated);
            }
            return updated;
        }

        public List<MovableDto> calcPosBatch(List<MovableDto> circles)
        {
            ConcurrentBag<MovableDto> result = new ConcurrentBag<MovableDto>();
            List<Task> movers = new List<Task>();
            foreach (MovableDto circle in circles)
            {
                movers.Add(new Task(() => result.Add(calcPos(circle))));
            }
            foreach (var mover in movers)
            {
                mover.Start();
            }
            Task.WaitAll(movers.ToArray());
            return new List<MovableDto>(result);
        }

        public List<MovableDto> InitCircles(int count)
        {
            List<MovableDto> circles = new List<MovableDto>();
            for (int i = 0; i < count; i++)
            {
                circles.Add(new CircleDto());
            }
            return positionGenerator.GeneratePosBatch(circles);
        }
        
        private MovableDto MoveCircle(MovableDto circle)
        {
            double xDir = circle.XDirection();
            double yDir = circle.YDirection();
            double vectorLen = Math.Sqrt(xDir * xDir + yDir * yDir);
            double xMove = Math.Min(circle.XPos + (xDir / vectorLen * speed), circle.XPos + xDir);
            double yMove = Math.Min(circle.YPos + (yDir / vectorLen * speed), circle.YPos + yDir);
            return new CircleDto(xMove, yMove, circle.TargetXPos, circle.TargetYPos);
        }
    }
}
