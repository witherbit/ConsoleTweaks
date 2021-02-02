using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public sealed class Position
    {
        public int Left { get; set; }
        public int Top { get; set; }

        public Position()
        {
            Left = 0;
            Top = 0;
        }

        public Position(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public override string ToString()
        {
            return $"{Top} {Left}";
        }

        public static Position operator+(Position pos1, Position pos2)
        {
            return new Position(pos1.Top + pos2.Top, pos1.Left + pos2.Left);
        }

        public static Position operator -(Position pos1, Position pos2)
        {
            return new Position(pos1.Top - pos2.Top, pos1.Left - pos2.Left);
        }

        public static Position operator *(Position pos1, Position pos2)
        {
            return new Position(pos1.Top * pos2.Top, pos1.Left * pos2.Left);
        }

        public static Position operator /(Position pos1, Position pos2)
        {
            return new Position(pos1.Top / pos2.Top, pos1.Left / pos2.Left);
        }
    }
}
