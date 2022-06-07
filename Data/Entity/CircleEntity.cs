using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Entity
{
    internal class CircleEntity : MovableEntity
    {
        private Task movement;
        private Stopwatch stopwatch = new Stopwatch();
        private int targetInterval = 10;

        public CircleEntity(double xPos, double yPos, double targetXPos,
            double targetYPos, PropertyChangedEventHandler propertyChanged) :
            base(xPos, yPos, targetXPos, targetYPos, propertyChanged)
        { }

        public override void StartMovement(CancellationToken cancellationToken)
        {
            movement = Movement(cancellationToken);
        }

        private async Task Movement(CancellationToken cancellationToken)
        {
            while(true)
            {
                stopwatch.Reset();
                stopwatch.Start();
                Move(stopwatch.ElapsedMilliseconds);
                stopwatch.Stop();
                await Task.Delay((int)(10), cancellationToken);
            }
        }

        public override void Move(float interval = 1, bool triggerPropChange = true)
        {
            try
            {
                TryLock();
                this.XPos += this.XDirection * ScreenParams.Speed * interval;
                this.YPos += this.YDirection * ScreenParams.Speed * interval;
            }
            finally
            {
                ReleaseLock();
                if (triggerPropChange)
                {
                    OnPropertyChanged();
                }
            }
        }

        public override void Update(double xDirection, double yDirection)
        {
            try
            {
                TryLock();
                this.XDirection = xDirection;
                this.YDirection = yDirection;
            }
            finally
            {
                ReleaseLock();
            }
        }
    }

}

