using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Serializable]
    public abstract class MovableEntity : INotifyPropertyChanged
    {
        private static int nextId = 1;
        private static Random random = new Random();

        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; private set; }
        public double XPos { get; private set; }
        public double YPos { get; private set; }
        public double XDirection { get; private set; }
        public double YDirection { get; private set; }

        protected Mutex mutex = new Mutex();

        public MovableEntity(double xPos, double yPos, double xDirection, double yDirection, PropertyChangedEventHandler propertyChanged)
        {
            Id = nextId++;
            XPos = xPos;
            YPos = yPos;
            XDirection = xDirection;
            YDirection = yDirection;
            PropertyChanged += propertyChanged;
        }

        public virtual void Move(float interval = 1, bool triggerPropChange = true)
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
                if(triggerPropChange)
                {
                    OnPropertyChanged();
                }
            }
        }

        public virtual void Update(double xDirection, double yDirection)
        {
            this.XDirection = xDirection;
            this.YDirection = yDirection;
        }
        public virtual void TryLock()
        {
            mutex.WaitOne();
        }
        public virtual void ReleaseLock()
        {
            mutex.ReleaseMutex();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
