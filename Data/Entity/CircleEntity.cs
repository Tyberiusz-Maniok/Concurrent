using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    internal class CircleEntity : MovableEntity
    {
        public CircleEntity(double xPos, double yPos, double targetXPos, double targetYPos) : base(xPos, yPos, targetXPos, targetYPos) { }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void ReleaseLock()
        {
            throw new NotImplementedException();
        }

        public override void TryLock()
        {
            throw new NotImplementedException();
        }

        public override void Update(double xDirection, double yDirection)
        {
            throw new NotImplementedException();
        }
    }
}
