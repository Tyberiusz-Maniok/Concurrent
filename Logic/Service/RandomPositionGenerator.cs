using Logic.Dto;
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

        private double ClampXPos(double pos)
        {
            if (pos <= circleRadius)
            {
                return circleRadius;
            }
            if (pos >= RECT_X * rectScale - circleRadius)
            {
                return RECT_X * rectScale - circleRadius;
            }
            return pos;
        }

        private double ClampYPos(double pos)
        {
            if (pos <= circleRadius)
            {
                return circleRadius;
            }
            if (pos >= RECT_Y * rectScale - circleRadius)
            {
                return RECT_Y * rectScale - circleRadius;
            }
            return pos;
        }

        public CircleDto GeneratePos(CircleDto circle)
        {
            return new CircleDto(circle.XPos, circle.YPos,
                ClampXPos(random.NextDouble() * RECT_X * rectScale),
                ClampYPos(random.NextDouble() * RECT_Y * rectScale));
        }

        public List<CircleDto> GeneratePosBatch(List<CircleDto> circles)
        {
            ConcurrentBag<CircleDto> result = new ConcurrentBag<CircleDto>();
            List<Task> generators = new List<Task>();
            foreach (CircleDto circle in circles)
            {
                generators.Add(new Task(() => result.Add(GeneratePos(circle))));
            }
            foreach(var generator in generators)
            {
                generator.Start();
            }
            Task.WaitAll(generators.ToArray());
            return new List<CircleDto>(result);
        }
    }
}
