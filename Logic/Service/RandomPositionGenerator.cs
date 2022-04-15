using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service
{
    public class RandomPositionGenerator : IPositionGenerator
    {
        private static readonly int RECT_X = 9;
        private static readonly int RECT_Y = 16;
        private Random random = new Random();
        private int rectScale;
        private double circleRadius;

        public RandomPositionGenerator(int rectScale, double circleRadius)
        {
            this.rectScale = rectScale;
            this.circleRadius = circleRadius;
        }

        public async Task<double> GenerateXPos()
        {
            throw new NotImplementedException();
        }

        public async Task<double> GenerateYPos()
        {
            throw new NotImplementedException();
        }

        public List<double> GenerateXPosBatch(int count)
        {
            throw new NotImplementedException();
        }

        public List<double> GenerateYPosBatch(int count)
        {
            throw new NotImplementedException();
        }
    }
}
