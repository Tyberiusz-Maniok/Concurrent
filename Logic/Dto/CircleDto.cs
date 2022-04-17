using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class CircleDto
    {
        public static readonly double Radius = 50.0;
        public double XPos { get; private set; }
        public double YPos { get; private set; }
        public double TargetXpos { get; private set; }
        public double TargetYPos { get; private set; }

        public CircleDto(double xPos, double yPos, double targetXPos, double targetYPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.TargetXpos = targetXPos;
            this.TargetYPos = targetYPos;
        }

        public CircleDto(double xPos, double yPos)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.TargetXpos = double.NaN;
            this.TargetYPos = double.NaN;
        }

        public CircleDto()
        {
            this.XPos = 0;
            this.YPos = 0;
            this.TargetXpos = double.NaN;
            this.TargetYPos = double.NaN;
        }
    }
}
