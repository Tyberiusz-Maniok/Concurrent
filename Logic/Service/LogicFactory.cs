using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Logic.Dto;

namespace Logic.Service
{
    public abstract class LogicFactory
    {
        public static MovableDto CreateCircle(double xPos, double yPos, double targetXPos, double targetYPos)
        {
            return new CircleDto(xPos, yPos, targetXPos, targetYPos);
        }

        public static ICircleMovementService GetCircleMovementService(int width, int height, double circleRadius, double speed)
        {
            return new PhysicsCircleMovementService(DataFactory.getCircleRepository(width, height, circleRadius, speed));
        }
    }
}
