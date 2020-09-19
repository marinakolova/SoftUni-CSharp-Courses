using System;
using System.Collections.Generic;
using System.Text;

namespace _2_PointInRectangle
{
    public class Point
    {
        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public Point(int coordinateX, int coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }
    }
}
