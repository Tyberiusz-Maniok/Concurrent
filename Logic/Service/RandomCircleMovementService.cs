using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    public class RandomCircleMovementService : ICircleMovementService
    {
        private IPositionGenerator positionGenerator;

        public RandomCircleMovementService(IPositionGenerator positionGenerator)
        {
            this.positionGenerator = positionGenerator;
        }

        public CircleDto calcPos(CircleDto current)
        {
            throw new NotImplementedException();
        }

        public List<CircleDto> calcPosBatch(List<CircleDto> circles)
        {
            throw new NotImplementedException();
        }

        public List<CircleDto> InitCircles(int count)
        {
            throw new NotImplementedException();
        }
    }
}
