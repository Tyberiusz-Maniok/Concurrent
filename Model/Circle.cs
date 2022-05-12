using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic.Dto;

namespace Model
{
    public class Circle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static readonly double radius = 25;
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double TargetXPos { get; private set; }
        public double TargetYPos { get; private set; }

        public Circle(double xPos, double yPos, double targetXPos, double targetYPos)
        {
            XPos = xPos;
            YPos = yPos;
            TargetXPos = targetXPos;
            TargetYPos = targetYPos;
        }

        public Circle(MovableDto circleDto)
        {
            XPos = circleDto.XPos;
            YPos = circleDto.YPos;
            TargetXPos = circleDto.XDirection;
            TargetYPos = circleDto.YDirection;

        }
    }
}
