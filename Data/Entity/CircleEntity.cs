using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    internal class CircleEntity : MovableEntity
    {
        public static readonly double Radius = 50.0;
        public CircleEntity(double xPos, double yPos, double targetXPos, double targetYPos) : base(xPos, yPos, targetXPos, targetYPos) { }
    }
}
