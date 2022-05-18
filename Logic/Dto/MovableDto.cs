using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Logic.Dto
{
    public abstract class MovableDto
    {
        private static Random random = new Random();
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double XDirection { get; set; }
        public double YDirection { get; set; }
        public int Id { get; set; } = 0;

        protected Mutex mutex = new Mutex();

        public MovableDto(double xPos, double yPos, double xDirection, double yDirection)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.XDirection = xDirection;
            this.YDirection = yDirection;
        }

        public MovableDto(double xPos, double yPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.XDirection = random.NextDouble();
            this.YDirection = Math.Sqrt(1 - XDirection);
        }

        public MovableDto()
        {
            this.XPos = ScreenParams.LowerBound();
            this.YPos = ScreenParams.LowerBound();
            this.XDirection = random.NextDouble();
            this.YDirection = Math.Sqrt(1 - XDirection);
        }

        public MovableDto(MovableEntity entity)
        {
            this.Id = entity.Id;
            this.XPos = entity.XPos;
            this.YPos = entity.YPos;
            this.XDirection = entity.XDirection;
            this.YDirection = entity.YDirection;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            MovableDto other = (MovableDto)obj;
            return this.XPos == other.XPos && this.YPos == other.YPos && this.XDirection == other.XDirection && this.YDirection == other.YDirection;
        }

        public virtual double DirectionMagnitude()
        {
            return Math.Sqrt(XDirection * XDirection + YDirection * YDirection);
        }

        public abstract double Distance(MovableDto other);

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
