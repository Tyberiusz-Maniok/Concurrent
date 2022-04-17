using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Dto
{
    public interface ICircleDtoRepository
    {
        CircleDto get(int index);
        List<CircleDto> getAll();
        List<CircleDto> findBy(Predicate<CircleDto> predicate);
        bool Add(CircleDto circleDto);
        bool Remove(CircleDto circleDto);
        void Create();
    }
}
