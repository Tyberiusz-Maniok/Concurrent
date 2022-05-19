using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Logic.Dto
{
    internal class CircleDto : MovableDto
    {
        public static readonly double Radius = 50.0;

        public CircleDto() : base() { }
        public CircleDto(double xPos, double yPos) : base(xPos, yPos) { }
        public CircleDto(double xPos, double yPos, double targetXPos, double targetYPos) : base(xPos, yPos, targetXPos, targetYPos) { }
        public CircleDto(MovableEntity entity) : base(entity) { }

        public override double Distance(MovableDto other)
        {
            double xDist = XPos - other.XPos;
            double yDist = YPos - other.YPos;
            return Math.Sqrt(xDist * xDist + yDist * yDist);
        }


        /*
        public abstract void ResolveWallCollision();
        public abstract void ResolveObjectCollision(MovableDto other);
        public virtual void TryLock()
        {
            mutex.WaitOne();
        }
        public virtual void ReleaseLock()
        {
            mutex.ReleaseMutex();
        }
        */
    }
}
