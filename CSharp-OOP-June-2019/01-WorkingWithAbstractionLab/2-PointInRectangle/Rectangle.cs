using System;
using System.Collections.Generic;
using System.Text;

namespace _2_PointInRectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public bool Contains(Point point)
        {
            bool isInsideByX = point.CoordinateX >= this.TopLeft.CoordinateX
                && point.CoordinateX <= this.BottomRight.CoordinateX;

            bool isInsideByY = point.CoordinateY >= this.TopLeft.CoordinateY
                && point.CoordinateY <= this.BottomRight.CoordinateY;

            return isInsideByX && isInsideByY;
        }
    }
}
