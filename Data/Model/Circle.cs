using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Circle
    {
        private static int next_uuid = 1;
        private int id { get; }
        private float radius { get; set; }
        private float x_pos { get; set; }
        private float y_pos { get; set; }
        private float x_dir { get; set; }
        private float y_dir { get; set; }
        private float velocity { get; set; }

        public Circle(float radius, float x_pos, float y_pos)
        {
        }

        public void UpdateMovement(float x_dir, float y_dir, float velocity)
        {
            throw new NotImplementedException();
        }
    }
}
