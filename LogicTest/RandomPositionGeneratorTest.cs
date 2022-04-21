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
            MovableDto circle = randomPositionGenerator.GeneratePos(new CircleDto());
            Assert.InRange(circle.XPos, 50.0, 15950.0);
            Assert.InRange(circle.TargetXPos, 50.0, 15950.0);
            Assert.InRange(circle.YPos, 50.0, 8950.0);
            Assert.InRange(circle.TargetYPos, 50.0, 8950.0);

            MovableDto circle2 = randomPositionGenerator.GeneratePos(new CircleDto(100, 200));
            Assert.Equal(100.0, circle2.XPos);
            Assert.InRange(circle.TargetXPos, 50.0, 15950.0);
            Assert.Equal(200.0, circle2.YPos);
            Assert.InRange(circle.TargetYPos, 50.0, 8950.0);
        }

        [Fact]
        public void TestGenerateXPosBatch()
        {
            List<MovableDto> circles = new List<MovableDto>();
            for (int i = 0; i < 10; i++)
            {
                circles.Add(new CircleDto());
            }
            List<MovableDto> c1 = randomPositionGenerator.GeneratePosBatch(circles);
            List<MovableDto> c2 = randomPositionGenerator.GeneratePosBatch(circles);
            Assert.Equal(10, c1.Count);
            Assert.Equal(10, c2.Count);
            Assert.NotEqual(c1, c2);
        }
    }
}
