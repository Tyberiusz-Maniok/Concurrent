using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dao
{
    public class DefaultCircleRepository : ICircleRepository
    {
        private List<Circle> circles;
        public void Add(Circle item)
        {
            throw new NotImplementedException();
        }

        public Circle Get(int id)
        {
            throw new NotImplementedException();
        }

        public LinkedList<Circle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Circle Remove(Circle item)
        {
            throw new NotImplementedException();
        }

        public void Update(Circle item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
