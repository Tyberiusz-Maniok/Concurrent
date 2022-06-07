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
        public double XPos { get; protected set; }
        public double YPos { get; protected set; }
        public double XDirection { get; protected set; }
        public double YDirection { get; protected set; }

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

        public abstract void StartMovement(CancellationToken cancellationToken);

        public abstract void Move(float interval = 1, bool triggerPropChange = true);

        public abstract void Update(double xDirection, double yDirection);

        protected virtual void TryLock()
        {
            mutex.WaitOne();
        }
        protected virtual void ReleaseLock()
        {
            mutex.ReleaseMutex();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
