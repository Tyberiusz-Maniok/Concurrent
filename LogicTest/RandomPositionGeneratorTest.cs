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
        public void TestGeneratePos()
        {
            double x = randomPositionGenerator.GeneratePos(true);
            Assert.InRange(x, 50.0, 15950.0);
            double y = randomPositionGenerator.GeneratePos(false);
            Assert.InRange(y, 50.0, 8950.0);
        }

        [Fact]
        public void TestGenerateXPosBatch()
        {
            List<double> x1 = randomPositionGenerator.GeneratePosBatch(20, true);
            List<double> x2 = randomPositionGenerator.GeneratePosBatch(20, true);
            Assert.NotEqual(x1, x2);
            List<double> y1 = randomPositionGenerator.GeneratePosBatch(20, false);
            List<double> y2 = randomPositionGenerator.GeneratePosBatch(20, false);
            Assert.NotEqual(y1, y2);
        }
    }
}
