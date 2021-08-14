using ConsoleTweaks.Models;
using ConsoleTweaks.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleTweaks.Elements
{
    public sealed class Frame
    {
        public Point Position { get; set; }

        public Point Size { get; set; }

        public string Color { get; set; }

        public List<FrameText> Inners = new List<FrameText>();

        public Frame(Point size, Point position, string color = TweakColor.White)
        {
            Position = position;
            Size = size;
            Color = color;
        }

        public void Update()
        {
            Position += Output.Cursor;
            Size += Position;

            for (int x = Position.Top; x <= Size.Top; x++)
            {
                for (int y = Position.Left; y <= Size.Left; y++)
                {
                    Output.Cursor = new Point(x, y);
                    if (x == Position.Top && y == Position.Left)
                    {
                        Output.Write(Color + "╔");
                    }
                    else if (x == Size.Top && y == Position.Left)
                    {
                        Output.Write(Color + "╚");
                    }
                    else if (x == Position.Top && y == Size.Left)
                    {
                        Output.Write(Color + "╗");
                    }
                    else if (x == Size.Top && y == Size.Left)
                    {
                        Output.Write(Color + "╝");
                    }
                    else if (x > Position.Top && x < Size.Top && y == Position.Left)
                    {
                        Output.Write(Color + "║");
                    }
                    else if (x == Position.Top || x == Size.Top)
                    {
                        Output.Write(Color + "═");
                    }
                    else if (x > Position.Top && x < Size.Top && y == Size.Left)
                    {
                        Output.Write(Color + "║");
                    }
                }
            }

			foreach(var text in Inners)
            {
				if (text.Position.Left < 0) text.Position.Left = 0;
				if (text.Position.Top < 0) text.Position.Top = 0;

				Output.Cursor = new Point(Position.Top + text.Position.Top + 1, Position.Left + text.Position.Left + 1);
				Output.Write(text.Text);
			}
            Output.Line();
        }
    }

    public sealed class FrameText
    {
        public Point Position { get; set; }
        public string Text { get; set; }
        public FrameText(Point position_in_frame, string text)
        {
            Position = position_in_frame;
            Text = text;
        }
    }
}
