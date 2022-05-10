using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LogicTest
{
    public class CircleDtoTest
    {
        [Fact]
        public void TestWallColission()
        {
            ScreenParams.Width = 100;
            ScreenParams.Height = 100;
            ScreenParams.CircleRadius = 50;
            MovableDto circle1 = new CircleDto(90, 50, 1, 0);
            Assert.True(circle1.WallCollision());
            MovableDto circle2 = new CircleDto(10, 50, 1, 0);
            Assert.True(circle2.WallCollision());
            MovableDto circle3 = new CircleDto(50, 90, 1, 0);
            Assert.True(circle3.WallCollision());
            MovableDto circle4 = new CircleDto(50, 10, 1, 0);
            Assert.True(circle4.WallCollision());
        }

       [Fact]
       public void TestObjectCollision()
        {
            ScreenParams.CircleRadius = 50;
            MovableDto circle1 = new CircleDto(60, 60, 1, 0);
            MovableDto circle2 = new CircleDto(100, 100, 1, 0);
            Assert.True(circle1.ObjectCollision(circle2));

            MovableDto circle3 = new CircleDto(60, 60, 1, 0);
            MovableDto circle4 = new CircleDto(1000, 1000, 1, 0);
            Assert.False(circle3.ObjectCollision(circle4));
        }
    }
}
