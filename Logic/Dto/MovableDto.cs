using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public abstract class MovableDto
    {
        //public static readonly double Radius = 50.0;
        public double XPos { get; private set; }
        public double YPos { get; private set; }
        public double TargetXPos { get; private set; }
        public double TargetYPos { get; private set; }

        public MovableDto(double xPos, double yPos, double targetXPos, double targetYPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.TargetXPos = targetXPos;
            this.TargetYPos = targetYPos;
        }

        public MovableDto(double xPos, double yPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.TargetXPos = double.NaN;
            this.TargetYPos = double.NaN;
        }

        public MovableDto()
        {
            this.XPos = 0;
            this.YPos = 0;
            this.TargetXPos = double.NaN;
            this.TargetYPos = double.NaN;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            MovableDto other = (MovableDto)obj;
            return this.XPos == other.XPos && this.YPos == other.YPos && this.TargetXPos == other.TargetXPos && this.TargetYPos == other.TargetYPos;
        }

        public abstract double XDirection();

        public abstract double YDirection();

        public abstract bool closeToTarget(double tolerance);
    }
}