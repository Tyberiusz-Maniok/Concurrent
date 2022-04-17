using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Service;
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
            /*randomPositionGenerator.Setup<double>(e => e.GeneratePos(true).Result).Returns(500.0);
            randomCircleMovementService = new RandomCircleMovementService(randomPositionGenerator.Object);
            Assert.Equal(500.0, randomCircleMovementService.calcPos(100));*/
        }


        [Fact]
        public void TestCalcPosBatch()
        {
            /*randomPositionGenerator.Setup<List<double>>(e => e.GeneratePosBatch(5, true))
                .Returns(new List<double>() { 500.0, 1000.0, 1500.0, 2000.0, 2500.0 });
            randomCircleMovementService = new RandomCircleMovementService(randomPositionGenerator.Object);*/
        }
    }
}
