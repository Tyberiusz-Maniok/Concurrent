﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Data.Entity
{
    internal class CircleEntity : MovableEntity
    {
        
        public CircleEntity(double xPos, double yPos, double targetXPos, double targetYPos) : base(xPos, yPos, targetXPos, targetYPos) { }
    }
}

