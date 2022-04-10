using Logic.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dao
{
    public class DefaultCircleRepository : ICircleRepository
    {
        private List<Circle> circles;
        private ICircleService circleService;

        public DefaultCircleRepository(ICircleService circleRepository)
        {
            this.circleService = circleRepository;
        }
        public void Add(Circle circle)
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

        public Circle Remove(Circle circle)
        {
            throw new NotImplementedException();
        }
    }
}
