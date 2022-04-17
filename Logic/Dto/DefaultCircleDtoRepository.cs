using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    internal class DefaultCircleDtoRepository : ICircleDtoRepository
    {
        private List<CircleDto> circles;
        public bool Add(CircleDto circleDto)
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public List<CircleDto> findBy(Predicate<CircleDto> predicate)
        {
            throw new NotImplementedException();
        }

        public CircleDto get(int index)
        {
            throw new NotImplementedException();
        }

        public List<CircleDto> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(CircleDto circleDto)
        {
            throw new NotImplementedException();
        }
    }
}
