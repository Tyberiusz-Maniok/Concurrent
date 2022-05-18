using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Data.Entity
{
    [Serializable]
    public abstract class MovableEntity : INotifyPropertyChanged
    {
        public static int nextId = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; private set; }
        public double XPos { get; private set; }
        public double YPos { get; private set; }
        public double XDirection { get; private set; }
        public double YDirection { get; private set; }

        public MovableEntity(double xPos, double yPos, double xDirection, double yDirection)
        {
            Id = nextId++;
            XPos = xPos;
            YPos = yPos;
            XDirection = xDirection;
            YDirection = yDirection;
        }

        public abstract void Move();
        public abstract void Update(double xDirection, double yDirection);
        public abstract void TryLock();
        public abstract void ReleaseLock();
    }
}
