using Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataTest
{
    public class CircleRepositoryTest
    {
        [Fact]
        public void CreateTest()
        {
            IMovableRepository circleRepo = new CircleRepository();
            circleRepo.Create(10);
/*            Assert.Equal(10, circleRepo.GetAll().Count());*/
        }
    }
}
