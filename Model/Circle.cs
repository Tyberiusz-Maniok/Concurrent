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

        public Circle(double xPos, double yPos, double targetXPos, double targetYPos) 
        {
            XPos = xPos;
            YPos = yPos;
            TargetXPos = targetXPos;
            TargetYPos = targetYPos;
        }

        public Circle(MovableDto circleDto) 
        {
            XPos = circleDto.XPos;
            YPos = circleDto.YPos;
            TargetXPos = circleDto.TargetXPos;
            TargetYPos= circleDto.TargetYPos;
           
        }
    }
}
