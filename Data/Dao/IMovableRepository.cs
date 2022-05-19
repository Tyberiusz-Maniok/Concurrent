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
        List<MovableEntity> Create(int count);
        void Update(int id, MovableEntity entity);
        void UpdateAll(List<MovableEntity> items);
    }
}
