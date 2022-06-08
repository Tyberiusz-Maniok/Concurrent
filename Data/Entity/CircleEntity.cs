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
        private int targetInterval = 30;

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
            while(!cancellationToken.IsCancellationRequested)
            {
                stopwatch.Reset();
                stopwatch.Start();
                Move(1);
                stopwatch.Stop();
                await Task.Delay((int)(targetInterval - stopwatch.ElapsedMilliseconds), cancellationToken);
            }
        }

        protected override void Move(float interval = 1, bool triggerPropChange = true)
        {
            try
            {
                TryLock();
                this.XPos += this.XDirection * ScreenParams.Speed * interval;
                this.YPos += this.YDirection * ScreenParams.Speed * interval;
                if (triggerPropChange)
                {
                    OnPropertyChanged();
                }
                //tu
            }
            finally
            {
                ReleaseLock();

            }
        }

        public override void Update(double xDirection, double yDirection, bool retrace)
        {
            try
            {
                TryLock();
                if (retrace)
                {
                    this.XPos += this.XDirection * ScreenParams.Speed * -0.5;
                    this.YPos += this.YDirection * ScreenParams.Speed * -0.5;
                }
                this.XDirection = xDirection;
                this.YDirection = yDirection;
            }
            finally
            {
                ReleaseLock();
            }
        }

        public override void StopMovement()
        {
            movement = null;
        }
    }

}

