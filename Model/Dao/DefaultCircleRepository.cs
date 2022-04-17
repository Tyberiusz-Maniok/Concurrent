using Logic.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dao
{
    public class DefaultCircleRepository : ICircleRepository
    {
        private List<Circle> circles;
        private ICircleMovementService circleMovementService;

        public DefaultCircleRepository(ICircleMovementService circleMovementService)
        {
            this.circleMovementService = circleMovementService;
            this.circles = new List<Circle>();
        }
        public bool Add(Circle circle)
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }


        public List<Circle> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Circle circle)
        {
            throw new NotImplementedException();
        }

        public void UpdateAllPosition()
        {
            throw new NotImplementedException();
        }

        public void UpdatePosition(Circle circle)
        {
            throw new NotImplementedException();
        }
    }
}
