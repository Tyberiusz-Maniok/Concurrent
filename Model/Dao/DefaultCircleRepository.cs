using Logic.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.Dto;

namespace Model.Dao
{
    public class DefaultCircleRepository : ICircleRepository
    {
        private List<Circle> circles;
        private List<Circle> Circles { get; set; }
        private ICircleMovementService circleMovementService;


        public DefaultCircleRepository(ICircleMovementService circleMovementService)
        {
            this.circleMovementService = circleMovementService;
            this.circles = new List<Circle>();
        }


        public List<Circle> GetAll()
        {
            return circles;
        }

        public void UpdateAllPosition()
        {
            List<MovableDto> circlesDto = new List<MovableDto>();
            List<Circle> result = new List<Circle>();

            foreach (Circle circle in this.circles)
            {
                circlesDto.Add(new CircleDto(circle.XPos, circle.YPos, circle.TargetXPos, circle.TargetYPos));
            }
            circlesDto = circleMovementService.calcPosBatch(circlesDto);
            foreach (MovableDto dto in circlesDto)
            {
                result.Add(new Circle(dto));
            }
            this.circles = result;
        }

        List<Circle> ICircleRepository.InitCircles(int numberOfCircles)
        {
            List<MovableDto> circlesDto = new List<MovableDto>();
            List<Circle> result = new List<Circle>();
            circlesDto = circleMovementService.InitCircles(numberOfCircles);

            foreach (MovableDto circle in circlesDto)
            {
                result.Add(new Circle(circle));
            }
            return result;
        }
    }
}
