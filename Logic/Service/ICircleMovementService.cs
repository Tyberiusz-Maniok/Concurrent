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
        void calcPosBatch();
        List<MovableDto> InitCircles(int count);

        List<MovableDto> GetCircles();
    }
}