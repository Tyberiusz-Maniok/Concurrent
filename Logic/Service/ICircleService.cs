using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    /// <summary>
    /// Class responsible for updating Circle data
    /// </summary>
    public interface ICircleService
    {
        double GenerateXPos();
        double GenerateYPos();
        List<double> GenerateXPosBatch();
        List<double> GenerateYPosBatch();
    }
}
