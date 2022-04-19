using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Dto;
using Logic.Service;
using Xunit;

namespace LogicTest
{
    public class RandomPositionGeneratorTest
    {
        IPositionGenerator randomPositionGenerator = new RandomPositionGenerator(1000, 50.0);

        [Fact]
        public void TestGeneratePos()
        {
            double x = randomPositionGenerator.GeneratePos(new CircleDto()).TargetXpos;
            Assert.InRange(x, 50.0, 15950.0);
            double y = randomPositionGenerator.GeneratePos(new CircleDto()).TargetYPos;
            Assert.InRange(y, 50.0, 8950.0);
        }

        [Fact]
        public void TestGenerateXPosBatch()
        {
            List<CircleDto> circles = new List<CircleDto>();
            for (int i = 0; i < 10; i++)
            {
                circles.Add(new CircleDto());
            }
            List<CircleDto> c1 = randomPositionGenerator.GeneratePosBatch(circles);
            List<CircleDto> c2 = randomPositionGenerator.GeneratePosBatch(circles);
            Assert.Equal(10, c1.Count);
            Assert.Equal(10, c2.Count);
            Assert.NotEqual(c1, c2);
        }
    }
}
