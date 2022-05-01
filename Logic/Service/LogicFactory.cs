using System;
using System.Collections.Generic;
using System.Text;
using Logic.Dto;

namespace Logic.Service
{
    public abstract class LogicFactory
    {
        public static MovableDto CreateCircle(double xPos, double yPos, double targetXPos, double targetYPos)
        {
            return new CircleDto(xPos, yPos, targetXPos, targetYPos);
        }
    }
}
