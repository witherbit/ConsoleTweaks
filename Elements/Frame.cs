using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace System
{
    public sealed class Frame
    {
        public Position Position { get; set; }

        public Position Size { get; set; }

        public string Color { get; set; }

        public List<FrameText> Inners = new List<FrameText>();

        public Frame(Position size, Position position, string color = TweakColor.White)
        {
            Position = position;
            Size = size;
            Color = color;
        }

        public void Draw()
        {
            Position += Tweak.Cursor;
            Size += Position;

            for (int x = Position.Top; x <= Size.Top; x++)
            {
                for (int y = Position.Left; y <= Size.Left; y++)
                {
                    Tweak.Cursor = new Position(x, y);
                    if (x == Position.Top && y == Position.Left)
                    {
                        Tweak.Write(Color + "╔");
                    }
                    else if (x == Size.Top && y == Position.Left)
                    {
                        Tweak.Write(Color + "╚");
                    }
                    else if (x == Position.Top && y == Size.Left)
                    {
                        Tweak.Write(Color + "╗");
                    }
                    else if (x == Size.Top && y == Size.Left)
                    {
                        Tweak.Write(Color + "╝");
                    }
                    else if (x > Position.Top && x < Size.Top && y == Position.Left)
                    {
                        Tweak.Write(Color + "║");
                    }
                    else if (x == Position.Top || x == Size.Top)
                    {
                        Tweak.Write(Color + "═");
                    }
                    else if (x > Position.Top && x < Size.Top && y == Size.Left)
                    {
                        Tweak.Write(Color + "║");
                    }
                }
            }

			foreach(var text in Inners)
            {
				if (text.Text.Length > Size.Left - 1) text.Text.Remove(Size.Left - 2);
				if (text.Position.Left < 0) text.Position.Left = 0;
				if (text.Position.Top < 0) text.Position.Top = 0;
                else if(text.Position.Top > Size.Top - 1)
                {
					text.Position.Top -= Size.Top - 2;
				}
				Tweak.Cursor = new Position(Position.Top + text.Position.Top + 1, Position.Left + text.Position.Left + 1);
				Tweak.Write(text.Text);
			}
            Tweak.Line();
        }
    }

    public sealed class FrameText
    {
        public Position Position { get; set; }
        public string Text { get; set; }
        public FrameText(Position position_in_frame, string text)
        {
            Position = position_in_frame;
            Text = text;
        }
    }
}
