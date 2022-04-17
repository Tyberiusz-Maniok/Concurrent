using Logic.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Service
{
    /// <summary>
    /// Interface responsible for updating circle's position
    /// </summary>
    public interface ICircleMovementService
    {
        CircleDto calcPos(CircleDto current);
        List<CircleDto> calcPosBatch();
        void InitCircles(int count);
    }
}
