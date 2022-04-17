using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public class CircleDto
    {
        private static readonly double radius = 50.0;
        private double xPos { get; set; }
        private double yPos { get; set; }
        private double targetXpos { get; set; }
        private double targetYPos { get; set; }

        public CircleDto(double targetXPos, double targetYPos)
        {
            this.xPos = 0;
            this.yPos = 0;
            this.targetXpos = targetXPos;
            this.targetYPos = targetYPos;
        }
    }
}
