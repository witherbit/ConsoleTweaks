using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTweaks.Models
{
    public sealed class Point
    {
        public int Left { get; set; }
        public int Top { get; set; }

        public Point()
        {
            Left = 0;
            Top = 0;
        }

        public Point(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public override string ToString()
        {
            return $"{Top} {Left}";
        }

        public static Point operator+(Point pos1, Point pos2)
        {
            return new Point(pos1.Top + pos2.Top, pos1.Left + pos2.Left);
        }

        public static Point operator -(Point pos1, Point pos2)
        {
            return new Point(pos1.Top - pos2.Top, pos1.Left - pos2.Left);
        }

        public static Point operator *(Point pos1, Point pos2)
        {
            return new Point(pos1.Top * pos2.Top, pos1.Left * pos2.Left);
        }

        public static Point operator /(Point pos1, Point pos2)
        {
            return new Point(pos1.Top / pos2.Top, pos1.Left / pos2.Left);
        }
    }
}
