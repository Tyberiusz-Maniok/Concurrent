using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Mappers
{
    internal interface IDaoToDtoMapper<T>
    {
        T Map(Object dao);
        List<T> MapAll(List<Object> daoList);
    }
}
