using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model
{
    public interface IDtoRepository<T>
    {
        List<T> getAll();
        T Get(int id);
    }
}
