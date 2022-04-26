using System;
using System.Collections.Generic;
using System.Text;
using Logic.Dto;

namespace Logic.Service
{
    internal class PositionGeneratorFactory
    {
        public IPositionGenerator GetPositionGenerator(int rectX, int rectY)
        {
            return new RandomPositionGenerator(rectX, rectY, CircleDto.Radius);
        }
    }
}
