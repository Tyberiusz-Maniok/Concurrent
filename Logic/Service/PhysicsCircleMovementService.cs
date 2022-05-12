using Data;
using Data.Dao;
using Data.Entity;
using Logic.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        /*
        public MovableDto calcPos(MovableDto dto)
        {
            throw new NotImplementedException();
        }
        */

        public List<MovableDto> calcPosBatch()
        {
            List<MovableDto> circles = EntityToDto(circleRepository.GetAll());
            List<Task> tasks = new List<Task>();
            foreach (MovableDto circle in circles)
            {
                tasks.Add(new Task(() => MoveCircle(circle, ref circles)));
            }
            foreach (Task task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks.ToArray());
            circleRepository.UpdateAll(DtoToEntity(circles));
            return circles;
        } 

        private void MoveCircle(MovableDto circle, ref List<MovableDto> circles)
        {
            circle.XPos += circle.XDirection * speed;
            circle.YPos += circle.YDirection * speed;
            circle.ResolveWallCollision();
            foreach (MovableDto other in circles)
            {
                circle.ResolveObjectCollision(other);
            }
        }

        public List<MovableDto> InitCircles(int count)
        {
            circleRepository.Create(count);
            return EntityToDto(circleRepository.GetAll());
        }

        private List<MovableEntity> DtoToEntity(List<MovableDto> circles)
        {
            List<MovableEntity> circleEntities = new List<MovableEntity>();
            foreach (MovableDto circle in circles)
            {
                MovableEntity circleEntity = DataFactory.CreateCicle(circle.XPos, circle.YPos, circle.XDirection, circle.YDirection);
                circleEntity.Id = circle.Id;
                circleEntities.Add(circleEntity);

            }
            return circleEntities;
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

        [Obsolete]
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

        [Obsolete]
        private void ResolveObjectCollision(ref MovableDto dto1, ref MovableDto dto2)
        {
            throw new NotImplementedException();
        }
    }
}
