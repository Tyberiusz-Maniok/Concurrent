using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    public class RandomPositionGenerator : IPositionGenerator
    {
        private static readonly int RECT_X = 9;
        private static readonly int RECT_Y = 16;
        private Random random = new Random();

        public double GenerateXPos()
        {
            throw new NotImplementedException();
        }

        public List<double> GenerateXPosBatch()
        {
            throw new NotImplementedException();
        }

        public double GenerateYPos()
        {
            throw new NotImplementedException();
        }

        public List<double> GenerateYPosBatch()
        {
            throw new NotImplementedException();
        }
    }
}
