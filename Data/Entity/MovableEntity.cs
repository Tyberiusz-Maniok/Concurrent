using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    [Serializable]
    public abstract class MovableEntity
    {
        [NonSerialized]
        public static int nextId = 1;
        public int Id { get; private set; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double TargetXPos { get; set; }
        public double TargetYPos { get; set; }

        public MovableEntity(double xPos, double yPos, double targetXPos, double targetYPos)
        {
            Id = nextId++;
            XPos = xPos;
            YPos = yPos;
            TargetXPos = targetXPos;
            TargetYPos = targetYPos;
        }
    }
}
