using Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dao
{
    public abstract class IMovableRepository
    {
        public abstract List<MovableEntity> Create(int count, PropertyChangedEventHandler propertyChanged);
        public virtual async Task Log(List<MovableEntity> circles) { }
    }
}
