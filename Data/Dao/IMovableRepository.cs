using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dao
{
    public interface IMovableRepository
    {
        List<MovableEntity> GetAll();
        MovableEntity Get(int id);
        void Create(int count, int xMax, int yMax);
        void UpdateAll(List<MovableEntity> items);
    }
}
