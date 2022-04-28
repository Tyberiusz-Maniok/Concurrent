using System;
using System.Collections.Generic;
using System.Text;
using Logic.Dto;

namespace Logic.Service
{
    public abstract class LogicFactory
    {
        public static IPositionGenerator GetRandomPositionGenerator(int rectX, int rectY)
        {
            return new RandomPositionGenerator(rectX, rectY, CircleDto.Radius);
        }

        public static ICircleMovementService GetRandomCircleMovementService(int rectX, int rectY, double speed)
        {
            return new RandomCircleMovementService(GetRandomPositionGenerator(rectX, rectY), speed);
        }

        public static MovableDto CreateCircle(double xPos, double yPos, double targetXPos, double targetYPos)
        {
            return new CircleDto(xPos, yPos, targetXPos, targetYPos);
        }
    }
}
