using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service
{
    /// <summary>
    /// Interface responsible for generating Circle position
    /// </summary>
    public interface IPositionGenerator
    {
        double GeneratePos(bool xOrY);
        <List<double> GeneratePosBatch(int count, bool xOrY);
    }
}
