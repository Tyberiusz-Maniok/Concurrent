using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
            double xDist = this.XPos - other.XPos;
            double yDist = this.YPos - other.YPos;
            return Math.Sqrt(xDist * xDist + yDist * yDist);
        }

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
    }
}
