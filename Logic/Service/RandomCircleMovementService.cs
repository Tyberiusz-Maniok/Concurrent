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

        public CircleDto calcPos(CircleDto circle)
        {
            CircleDto updated = MoveCircle(circle);
            if (IsCloseToTarget(updated))
            {
                updated = positionGenerator.GeneratePos(updated);
            }
            return updated;
        }

        public List<CircleDto> calcPosBatch(List<CircleDto> circles)
        {
            ConcurrentBag<CircleDto> result = new ConcurrentBag<CircleDto>();
            List<Task> movers = new List<Task>();
            foreach (CircleDto circle in circles)
            {
                movers.Add(new Task(() => result.Add(calcPos(circle))));
            }
            foreach (var mover in movers)
            {
                mover.Start();
            }
            Task.WaitAll(movers.ToArray());
            return new List<CircleDto>(result);
        }

        public List<CircleDto> InitCircles(int count)
        {
            List<CircleDto> circles = new List<CircleDto>();
            for (int i = 0; i < count; i++)
            {
                circles.Add(new CircleDto());
            }
            return positionGenerator.GeneratePosBatch(circles);
        }

        private bool IsCloseToTarget(CircleDto circle)
        {
            return Math.Abs(circle.XDirection()) < tolerance && Math.Abs(circle.YDirection()) < tolerance;
        }
        
        private CircleDto MoveCircle(CircleDto circle)
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
