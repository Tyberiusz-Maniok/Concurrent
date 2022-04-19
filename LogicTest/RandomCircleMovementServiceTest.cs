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
            CircleDto circle = new CircleDto(CircleDto.Radius, CircleDto.Radius, 1000.0, 1000.0);
            randomPositionGenerator.Setup(e => e.GeneratePos(new CircleDto())).Returns(circle);
            randomCircleMovementService = new RandomCircleMovementService(randomPositionGenerator.Object);
            Assert.Equal(circle, randomCircleMovementService.calcPos(new CircleDto()));
        }


        [Fact]
        public void TestCalcPosBatch()
        {
            List<CircleDto> circleExpected = new List<CircleDto>();
            List<CircleDto> circlesInit = new List<CircleDto>();
            for (int i = 1; i < 11; i++)
            {
                circleExpected.Add(new CircleDto(CircleDto.Radius, CircleDto.Radius, i * 100.0, i * 100.0));
                circlesInit.Add(new CircleDto());
            }
            randomPositionGenerator.Setup(e => e.GeneratePosBatch(circlesInit)).Returns(circleExpected);
            randomCircleMovementService = new RandomCircleMovementService(randomPositionGenerator.Object);
            List<CircleDto> circleResults = randomCircleMovementService.calcPosBatch(circlesInit);
            Assert.Equal(circleResults.Count, circleExpected.Count);
            Assert.Equal(circleExpected, circleResults);
        }
    }
}
