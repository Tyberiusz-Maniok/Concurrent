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

        public override bool ObjectCollision(MovableDto other)
        {
            return Math.Abs(this.DirectionMagnitude() - other.DirectionMagnitude()) < Radius;
        }

        public override bool WallCollision()
        {
            throw new NotImplementedException();
        }
    }
}
