using Logic.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service
{
    internal class RandomPositionGenerator : IPositionGenerator
    {
        private Random random = new Random();
        private int rectX;
        private int rectY;
        private double circleRadius;

        public RandomPositionGenerator(int rectX, int rectY, double circleRadius)
        {
            this.rectX = rectX;
            this.rectY = rectY;
            this.circleRadius = circleRadius;
        }

        private double ClampXPos(double pos)
        {
            if (pos <= circleRadius)
            {
                return circleRadius;
            }
            if (pos >= rectX - circleRadius)
            {
                return rectX - circleRadius;
            }
            return pos;
        }

        private double ClampYPos(double pos)
        {
            if (pos <= circleRadius)
            {
                return circleRadius;
            }
            if (pos >= rectY - circleRadius)
            {
                return rectY - circleRadius;
            }
            return pos;
        }

        public MovableDto GeneratePos(MovableDto circle)
        {
            double xPos = circle.XPos;
            double yPos = circle.YPos;
            if (xPos < circleRadius)
            {
                xPos = ClampXPos(random.NextDouble() * rectX);
            }
            if (yPos < circleRadius)
            {
                yPos = ClampYPos(random.NextDouble() * rectY);
            }
            return new CircleDto(xPos, yPos,
                ClampXPos(random.NextDouble() * rectX),
                ClampYPos(random.NextDouble() * rectY));
        }

        public List<MovableDto> GeneratePosBatch(List<MovableDto> circles)
        {
            ConcurrentBag<MovableDto> result = new ConcurrentBag<MovableDto>();
            List<Task> generators = new List<Task>();
            foreach (MovableDto circle in circles)
            {
                generators.Add(new Task(() => result.Add(GeneratePos(circle))));
            }

            foreach (var generator in generators)

            {
                generator.Start();
            }
            Task.WaitAll(generators.ToArray());
            return new List<MovableDto>(result);
        }
    }
}