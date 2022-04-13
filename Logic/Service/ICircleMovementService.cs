using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    public interface ICircleMovementService
    {
        double calcXPos(double currentXPos);
        double calcYPos(double currentYPos);
        List<double> calcXPosBatch(List<double> currentXPos);
        List<double> calcYPosBatch(List<double> currentYPos);
    }
}
