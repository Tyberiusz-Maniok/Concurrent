using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dao
{
    public interface ICircleRepository
    {
        List<Circle> GetAll();
        void Create();
        void Add(Circle circle);
        Circle Remove(Circle circle);
        void UpdatePosition(Circle circle);
        void UpdateAllPosition();
    }
}
