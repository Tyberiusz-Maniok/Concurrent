using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class CircleDto : MovableDto
    {
        public static readonly double Radius = 50.0;

        public CircleDto() :base() { }
        public CircleDto(double xPos, double yPos) : base(xPos, yPos) { }
        public CircleDto(double xPos, double yPos, double targetXPos, double targetYPos) : base(xPos, yPos, targetXPos, targetYPos) { }

        public override double XDirection()
        {
            if (Double.IsNaN(TargetXPos))
            {
                return 0;
            }
            return this.TargetXPos - this.XPos;
        }

        public override double YDirection()
        {
            if (Double.IsNaN(TargetYPos))
            {
                return 0;
            }
            return this.TargetYPos - this.YPos;
        }

        public override bool closeToTarget(double tolerance)
        {
            return Math.Abs(XDirection()) < tolerance && Math.Abs(YDirection()) < tolerance;
        }
    }
}
