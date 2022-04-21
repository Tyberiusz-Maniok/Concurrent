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
        private static readonly int RECT_X = 16;
        private static readonly int RECT_Y = 9;
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

        public MovableDto GeneratePos(MovableDto circle)
        {
            double xPos = circle.XPos;
            double yPos = circle.YPos;
            if (xPos < circleRadius)
            {
                xPos = ClampXPos(random.NextDouble() * RECT_X * rectScale);
            }
            if (yPos < circleRadius)
            {
                yPos = ClampYPos(random.NextDouble() * RECT_Y * rectScale);
            }
            return new CircleDto(xPos, yPos,
                ClampXPos(random.NextDouble() * RECT_X * rectScale),
                ClampYPos(random.NextDouble() * RECT_Y * rectScale));
        }

        public List<MovableDto> GeneratePosBatch(List<MovableDto> circles)
        {
            ConcurrentBag<MovableDto> result = new ConcurrentBag<MovableDto>();
            List<Task> generators = new List<Task>();
            foreach (MovableDto circle in circles)
            {
                generators.Add(new Task(() => result.Add(GeneratePos(circle))));
            }
            foreach(var generator in generators)
            {
                generator.Start();
            }
            Task.WaitAll(generators.ToArray());
            return new List<MovableDto>(result);
        }
    }
}
