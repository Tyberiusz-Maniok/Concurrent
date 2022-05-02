using Logic.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.Dto;

namespace Model.Dao
{
    public class DefaultCircleRepository : ICircleRepository
    {
        private List<Circle> Circles { get; set; }
        private ICircleMovementService circleMovementService;


        public DefaultCircleRepository(ICircleMovementService circleMovementService)
        {
            this.circleMovementService = circleMovementService;
            Circles = new List<Circle>();
        }

        public List<Circle> GetAll()
        {
            return Circles;
        }

        public void UpdateAllPosition()
        {
            List<MovableDto> circlesDto = circleMovementService.calcPosBatch();
            List<Circle> result = new List<Circle>();
            foreach (MovableDto dto in circlesDto)
            {
                result.Add(new Circle(dto));
            }
            Circles = result;
        }

        List<Circle> ICircleRepository.InitCircles(int numberOfCircles)
        {
            List<Circle> result = new List<Circle>();
            List<MovableDto> circlesDto = circleMovementService.InitCircles(numberOfCircles);
            foreach (MovableDto circle in circlesDto)
            {
                result.Add(new Circle(circle));
            }
            Circles = result;
            return result;
        }
    }
}
