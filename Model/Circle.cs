using System;
using Logic.Dto;

namespace Model
{
    public class Circle
    {
        //TODO set some default value for this property
        public static readonly double radius = 50;
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double TargetXPos { get; private set; }
        public double TargetYPos { get; private set; }

        public Circle(double xPos, double yPos, double targetXPos, double targetYPos) { }

        public Circle(MovableDto circleDto) 
        {
            
        }
    }
}
