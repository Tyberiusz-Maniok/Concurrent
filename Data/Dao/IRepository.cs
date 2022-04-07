using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dao
{
    public interface IRepository<T>
    {
        LinkedList<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T item, int id);
        T Remove(T item);

    }
}
