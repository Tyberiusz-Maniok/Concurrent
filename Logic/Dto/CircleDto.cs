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
        public override bool ObjectCollision(MovableDto other)
        {
            return Distance(other) < ScreenParams.CircleRadius * 2;
        }

        public override bool WallCollision()
        {
            if (this.XPos < ScreenParams.LowerBound() ||
                    this.YPos < ScreenParams.LowerBound() || 
                    this.XPos > ScreenParams.UpperXBound() ||
                    this.YPos > ScreenParams.UpperYBound())
            {
                return true;
            }
            return false;
        }
        */

        public override void ResolveWallCollision()
        {
            try
            {
                TryLock();
                if (XPos < ScreenParams.LowerBound())
                {
                    double diff = Math.Abs(XPos - ScreenParams.LowerBound());
                    XPos += diff;
                    XDirection *= -1;
                }
                if (YPos < ScreenParams.LowerBound())
                {
                    double diff = Math.Abs(YPos - ScreenParams.LowerBound());
                    YPos += diff;
                    YDirection *= -1;
                }
                if (XPos > ScreenParams.UpperXBound())
                {
                    double diff = Math.Abs(YPos - ScreenParams.UpperXBound());
                    XPos -= diff;
                    XDirection *= -1;
                }
                if (YPos > ScreenParams.UpperYBound())
                {
                    double diff = Math.Abs(YPos - ScreenParams.UpperYBound());
                    YPos -= diff;
                    YDirection *= -1;
                }
            }
            finally
            {
                ReleaseLock();
            }
        }

        public override void ResolveObjectCollision(MovableDto other)
        {
            try
            {
                if (Id < other.Id)
                {
                    TryLock();
                    other.TryLock();
                }
                else
                {
                    other.TryLock();
                    TryLock();
                }
                double distance = Distance(other);
                bool willCollide = false;
                if (distance < ScreenParams.CircleRadius * 2)
                {
                    willCollide = true;
                }
                if (willCollide)
                {
                    double overlap = (ScreenParams.CircleRadius * 2 - distance) / 2;
                    double xDir = other.XDirection - XDirection;
                    double yDir = other.YDirection - YDirection;
                    XPos -= xDir * overlap;
                    YPos -= yDir * overlap;
                    other.XPos += xDir * overlap;
                    other.YPos += yDir * overlap;
                    double xPerpendicular = -yDir;
                    double yPerpendicular = xDir;
                    double response1 = XDirection * xPerpendicular + YDirection * yPerpendicular;
                    double response2 = other.XDirection * xPerpendicular + other.YDirection * yPerpendicular;
                    XDirection = xPerpendicular * response1;
                    YDirection = yPerpendicular * response1;
                    other.XDirection = xPerpendicular * response2;
                    other.YDirection = yPerpendicular * response2;
                }
            }
            finally
            {
                other.ReleaseLock();
                ReleaseLock();
            }
        }
    }
}
