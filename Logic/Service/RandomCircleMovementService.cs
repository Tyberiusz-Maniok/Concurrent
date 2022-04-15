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

        public double calcXPos(double currentXPos)
        {
            throw new NotImplementedException();
        }

        public List<double> calcXPosBatch(List<double> currentXPos)
        {
            throw new NotImplementedException();
        }

        public double calcYPos(double currentYPos)
        {
            throw new NotImplementedException();
        }

        public List<double> calcYPosBatch(List<double> currentYPos)
        {
            throw new NotImplementedException();
        }
    }
}
