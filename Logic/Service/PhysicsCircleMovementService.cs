using Data.Dao;
using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    internal class PhysicsCircleMovementService : ICircleMovementService
    {
        private IMovableRepository circleRepository;
        private double speed;

        public PhysicsCircleMovementService(IMovableRepository circleRepository, double speed)
        {
            this.circleRepository = circleRepository;
            this.speed = speed;
        }

        public MovableDto calcPos()
        {
            throw new NotImplementedException();
        }

        public List<MovableDto> calcPosBatch()
        {
            throw new NotImplementedException();
        }

        public List<MovableDto> InitCircles(int count)
        {
            throw new NotImplementedException();
        }
    }
}
