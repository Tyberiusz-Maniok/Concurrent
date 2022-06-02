using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Data.Entity
{
    internal class CircleEntity : MovableEntity
    {
        
        public CircleEntity(double xPos, double yPos, double targetXPos,
            double targetYPos, PropertyChangedEventHandler propertyChanged) :
            base(xPos, yPos, targetXPos, targetYPos, propertyChanged) { }
    }

}

