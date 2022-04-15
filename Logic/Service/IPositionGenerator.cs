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
        Task<double> GenerateXPos();
        Task<double> GenerateYPos();
        List<double> GenerateXPosBatch(int count);
        List<double> GenerateYPosBatch(int count);
    }
}
