using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dao
{
    public interface ICircleRepository
    {
        List<Circle> GetAll();
        void UpdateAllPosition();
        List<Circle> InitCircles(int numberOfCircles);
    }
}
