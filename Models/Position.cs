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
    }
}
