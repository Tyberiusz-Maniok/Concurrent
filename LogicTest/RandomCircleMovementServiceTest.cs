using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Service;
using Logic.Dto;
using Xunit;
using Moq;

namespace LogicTest
{
    public class RandomCircleMovementServiceTest
    {
        private Mock<IPositionGenerator> randomPositionGenerator = new Mock<IPositionGenerator>();
        private ICircleMovementService randomCircleMovementService;

        [Fact]
        public void TestCalcPos()
        {
            MovableDto expectedCircle = new CircleDto(200, 100, 1000.0, 100);
            MovableDto inputCircle = new CircleDto(100, 100, 1000, 100);
            randomPositionGenerator.Setup(e => e.GeneratePos(inputCircle)).Returns(expectedCircle);
            randomCircleMovementService = new RandomCircleMovementService(randomPositionGenerator.Object, 100);
            Assert.Equal(expectedCircle, randomCircleMovementService.calcPos(inputCircle));
        }


        [Fact]
        public void TestCalcPosBatch()
        {
            MovableDto initCircle = new CircleDto(100, 100, 1000, 100);
            MovableDto expectedCircle = new CircleDto(200, 100, 1000, 100);
            List<MovableDto> circlesExpected = new List<MovableDto>();
            List<MovableDto> circlesInit = new List<MovableDto>();
            for (int i = 1; i < 11; i++)
            {
                circlesExpected.Add(expectedCircle);
                circlesInit.Add(initCircle);
            }
            randomPositionGenerator.Setup(e => e.GeneratePos(initCircle)).Returns(expectedCircle);
            randomCircleMovementService = new RandomCircleMovementService(randomPositionGenerator.Object, 100.0);
            List<MovableDto> circleResults = randomCircleMovementService.calcPosBatch(circlesInit);
            Assert.Equal(circleResults.Count, circlesExpected.Count);
            Assert.Equal(circlesExpected, circleResults);
        }
    }
}
