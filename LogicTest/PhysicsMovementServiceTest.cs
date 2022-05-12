using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Data.Dao;
using Logic.Service;
using Data.Entity;

namespace LogicTest
{
    public class PhysicsMovementServiceTest
    {
        [Fact]
        public void TestInitiCrcles()
        {
            Mock<IMovableRepository> circleRepo = new Mock<IMovableRepository>();
            List<MovableEntity> entities = Enumerable.Repeat((MovableEntity) new CircleEntity(0, 0, 0, 0), 10).ToList();
            circleRepo.Setup(_ => _.Create(10)).Verifiable();
            circleRepo.Setup(_ => _.GetAll()).Returns(entities);
            ICircleMovementService service = new PhysicsCircleMovementService(circleRepo.Object, 10);
            Assert.Equal(10, service.InitCircles(10).Count);
            circleRepo.Verify(_ => _.Create(10), Times.Once());
            circleRepo.Verify(_ => _.GetAll(), Times.Once());
        }
    }
}
