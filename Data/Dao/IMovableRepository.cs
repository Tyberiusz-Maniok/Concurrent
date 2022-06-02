using Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Data.Dao
{
    public interface IMovableRepository
    {
        List<MovableEntity> Create(int count, PropertyChangedEventHandler propertyChanged);
    }
}
