using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    /// <summary>
    /// Interface responsible for generating Circle position
    /// </summary>
    public interface IPositionGenerator
    {
        double GenerateXPos();
        double GenerateYPos();
        List<double> GenerateXPosBatch();
        List<double> GenerateYPosBatch();
    }
}
