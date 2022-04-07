using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    /// <summary>
    /// Class responsible for performing
    /// </summary>
    public interface IService<T>
    {
        /// <summary>
        /// Fetch all entities from
        /// </summary>
        /// <returns>All entities</returns>
        List<T> FindAll();
        /// <summary>
        /// Find entity by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity with corresponding id or null if not found</returns>
        T findById(int id);


    }
}
