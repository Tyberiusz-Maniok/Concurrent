using Data.Dao;
using Data.Entity;
using Logic.Dto;
using System;
using System.Collections.Concurrent;
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

        public MovableDto calcPos(MovableDto dto)
        {
            return MoveCircle(dto, null);
        }

        public List<MovableDto> calcPosBatch()
        {
            throw new NotImplementedException();
        }

        public List<MovableDto> InitCircles(int count)
        {
            circleRepository.Create(count);
            return EntityToDto(circleRepository.GetAll());
        }

        private List<MovableDto> EntityToDto(List<MovableEntity> entities)
        {
            List<MovableDto> result = new List<MovableDto>();
            foreach (MovableEntity entity in entities)
            {
                result.Add(new CircleDto(entity));
            }
            return result;
        }

        private MovableDto MoveCircle(MovableDto circle, BlockingCollection<MovableDto> allCircles)
        {
            circle = ResolveWallCollision(circle);
            List<MovableDto> willCollide = FindCollisions(circle);

            throw new NotImplementedException();
        }

        private MovableDto ResolveWallCollision(MovableDto circle)
        {
            if (circle.XPos < ScreenParams.LowerBound())
            {
                double diff = Math.Abs(circle.XPos - ScreenParams.LowerBound());
                circle.XPos = circle.XPos + diff;
                circle.XDirection = -circle.XDirection;
            }
            if (circle.YPos < ScreenParams.LowerBound())
            {
                double diff = Math.Abs(circle.YPos - ScreenParams.LowerBound());
                circle.YPos = circle.YPos + diff;
                circle.YDirection = -circle.YDirection;
            }
            if (circle.XPos > ScreenParams.UpperXBound())
            {
                double diff = Math.Abs(circle.YPos - ScreenParams.UpperXBound());
                circle.XPos = circle.XPos - diff;
                circle.XDirection = -circle.XDirection;
            }
            if (circle.YPos > ScreenParams.UpperYBound())
            {
                double diff = Math.Abs(circle.YPos - ScreenParams.UpperYBound());
                circle.YPos = circle.YPos - diff;
                circle.YDirection = -circle.YDirection;
            }
            return circle;
        }

        private void ResolveObjectCollision(ref MovableDto dto1, ref MovableDto dto2)
        {
            throw new NotImplementedException();
        }

        private List<MovableDto> FindCollisions(MovableDto circle)
        {
            List<MovableDto> willCollide = new List<MovableDto>();
            foreach (MovableDto mov in EntityToDto(circleRepository.GetAll()))
            {
                if (!circle.Equals(mov) && circle.ObjectCollision(mov))
                {
                    willCollide.Add(mov);
                }
            }
            return willCollide;
        }
    }
}
