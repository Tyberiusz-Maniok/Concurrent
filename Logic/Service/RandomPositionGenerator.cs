using System;
using System.Collections.Concurrent;
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

        public double GeneratePos(bool xOrY)
        {
            return random.NextDouble() * (xOrY ? RECT_X : RECT_Y) * rectScale;
        }

        private void AddNewPosition(ConcurrentBag<double> bag, bool xOrY)
        {
            bag.Add(GeneratePos(xOrY));
        }

        public List<double> GeneratePosBatch(int count, bool xOrY)
        {
            ConcurrentBag<double> result = new ConcurrentBag<double>();
            for (int i = 0; i < count; i++)
            {
                Task.Run(() => AddNewPosition(result, xOrY));
            }
            return new List<double>(result);
        }
    }
}
