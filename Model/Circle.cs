﻿using System;

namespace Model
{
    public class Circle
    {
        //TODO set some default value for this property
        private static readonly double radius = 50.0;
        private double xPos { get; set; }
        private double yPos { get; set; }
        public Circle(double xPos, double yPos) { }
    }
}