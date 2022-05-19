using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

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

        public MovableEntity(double xPos, double yPos, double xDirection, double yDirection)
        {
            Id = nextId++;
            XPos = xPos;
            YPos = yPos;
            XDirection = xDirection;
            YDirection = yDirection;
        }


        public virtual void Move()
        {
            try
            {
                TryLock();
                this.XPos += this.XDirection * ScreenParams.Speed;
                this.YPos += this.YDirection * ScreenParams.Speed;
                

            }
            finally
            {
                ReleaseLock();
                OnPropertyChanged();
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

        public abstract void Move();
        public abstract void Update(double xDirection, double yDirection);
        public abstract void TryLock();
        public abstract void ReleaseLock();
    }
}
