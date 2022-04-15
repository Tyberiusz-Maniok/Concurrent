using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Service;
using Xunit;

namespace LogicTest
{
    public class RandomPositionGeneratorTest
    {
        IPositionGenerator randomPositionGenerator = new RandomPositionGenerator(1000, 50.0);

        [Fact]
        public async void TestGenerateXPos()
        {
            double x = await randomPositionGenerator.GenerateXPos();
            Assert.InRange(x, 50.0, 15950.0);
        }

        [Fact]
        public async void TestGenerateYPos()
        {
            double y = await randomPositionGenerator.GenerateYPos();
            Assert.InRange(y, 50.0, 8950.0);
        }

        [Fact]
        public void TestGenerateXPosBatch()
        {
            List<double> x1 = randomPositionGenerator.GenerateXPosBatch(5);
            List<double> x2 = randomPositionGenerator.GenerateXPosBatch(5);
            Assert.NotEqual(x1, x2);
        }

        [Fact]
        public void TestGenerateYPosBatch()
        {
            List<double> y1 = randomPositionGenerator.GenerateYPosBatch(5);
            List<double> y2 = randomPositionGenerator.GenerateYPosBatch(5);
            Assert.NotEqual(y1, y2);
        }
    }
}
