using Logic.Dto;
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
        CircleDto GeneratePos(CircleDto circle);
        List<CircleDto> GeneratePosBatch(List<CircleDto> circles);
    }
}
