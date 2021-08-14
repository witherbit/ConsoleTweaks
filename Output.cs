using ConsoleTweaks.Models;
using ConsoleTweaks.Utils;
using System;

namespace ConsoleTweaks
{
    public static class Output
    {
        internal static object _locker = new object();
        public static Point Cursor
        {
            get
            {
                return new Point(Console.CursorTop, Console.CursorLeft);
            }
            set
            {
                Console.SetCursorPosition(value.Left, value.Top);
            }
        }

        public static ConsoleColor Foreground
        { 
            get
            {
                return Console.ForegroundColor;
            }
            set
            {
                Console.ForegroundColor = value;
            }    
        }

        public static ConsoleColor Background
        {
            get
            {
                return Console.BackgroundColor;
            }
            set
            {
                Console.BackgroundColor = value;
            }
        }

        public static void Write(object value)
        {
            var defcol = Foreground;
            string text = value.ToString();
            text = text
                .Replace($"{TweakColor.Black}", $"{TweakColor.Black}{TweakColor.ShortBlack}")
                .Replace($"{TweakColor.Blue}", $"{TweakColor.Blue}{TweakColor.ShortBlue}")
                .Replace($"{TweakColor.Cyan}", $"{TweakColor.Cyan}{TweakColor.ShortCyan}")
                .Replace($"{TweakColor.DarkBlue}", $"{TweakColor.DarkBlue}{TweakColor.ShortDarkBlue}")
                .Replace($"{TweakColor.DarkCyan}", $"{TweakColor.DarkCyan}{TweakColor.ShortDarkCyan}")
                .Replace($"{TweakColor.DarkGray}", $"{TweakColor.DarkGray}{TweakColor.ShortDarkGray}")
                .Replace($"{TweakColor.DarkGreen}", $"{TweakColor.DarkGreen}{TweakColor.ShortDarkGreen}")
                .Replace($"{TweakColor.DarkMagenta}", $"{TweakColor.DarkMagenta}{TweakColor.ShortDarkMagenta}")
                .Replace($"{TweakColor.DarkRed}", $"{TweakColor.DarkRed}{TweakColor.ShortDarkRed}")
                .Replace($"{TweakColor.DarkYellow}", $"{TweakColor.DarkYellow}{TweakColor.ShortDarkYellow}")
                .Replace($"{TweakColor.Gray}", $"{TweakColor.Gray}{TweakColor.ShortGray}")
                .Replace($"{TweakColor.Green}", $"{TweakColor.Green}{TweakColor.ShortGreen}")
                .Replace($"{TweakColor.Magenta}", $"{TweakColor.Magenta}{TweakColor.ShortMagenta}")
                .Replace($"{TweakColor.Red}", $"{TweakColor.Red}{TweakColor.ShortRed}")
                .Replace($"{TweakColor.White}", $"{TweakColor.White}{TweakColor.ShortWhite}")
                .Replace($"{TweakColor.Yellow}", $"{TweakColor.Yellow}{TweakColor.ShortYellow}")
                ;
            string[] ctext = text.Split(new string[] 
            { 
                TweakColor.Black, TweakColor.Blue, TweakColor.Cyan, TweakColor.DarkBlue, TweakColor.DarkCyan, TweakColor.DarkGray, TweakColor.DarkGreen, TweakColor.DarkMagenta,
                TweakColor.DarkRed, TweakColor.DarkRed, TweakColor.DarkYellow, TweakColor.Gray, TweakColor.Green, TweakColor.Magenta, TweakColor.Red, TweakColor.White, TweakColor.Yellow
            }, StringSplitOptions.RemoveEmptyEntries);
            lock (_locker)
            foreach (var cth in ctext)
            {
                if (cth.Contains(TweakColor.ShortBlack))
                {
                    Foreground = ConsoleColor.Black;
                    Console.Write(cth.Replace(TweakColor.ShortBlack, ""));
                }
                else if (cth.Contains(TweakColor.ShortBlue))
                {
                    Foreground = ConsoleColor.Blue;
                    Console.Write(cth.Replace(TweakColor.ShortBlue, ""));
                }
                else if (cth.Contains(TweakColor.ShortCyan))
                {
                    Foreground = ConsoleColor.Cyan;
                    Console.Write(cth.Replace(TweakColor.ShortCyan, ""));
                }
                else if (cth.Contains(TweakColor.ShortDarkBlue))
                {
                    Foreground = ConsoleColor.DarkBlue;
                    Console.Write(cth.Replace(TweakColor.ShortDarkBlue, ""));
                }
                else if (cth.Contains(TweakColor.ShortDarkCyan))
                {
                    Foreground = ConsoleColor.DarkCyan;
                    Console.Write(cth.Replace(TweakColor.ShortDarkCyan, ""));
                }
                else if (cth.Contains(TweakColor.ShortDarkGray))
                {
                    Foreground = ConsoleColor.DarkGray;
                    Console.Write(cth.Replace(TweakColor.ShortDarkGray, ""));
                }
                else if (cth.Contains(TweakColor.ShortDarkGreen))
                {
                    Foreground = ConsoleColor.DarkGreen;
                    Console.Write(cth.Replace(TweakColor.ShortDarkGreen, ""));
                }
                else if (cth.Contains(TweakColor.ShortDarkMagenta))
                {
                    Foreground = ConsoleColor.DarkMagenta;
                    Console.Write(cth.Replace(TweakColor.ShortDarkMagenta, ""));
                }
                else if (cth.Contains(TweakColor.ShortDarkRed))
                {
                    Foreground = ConsoleColor.DarkRed;
                    Console.Write(cth.Replace(TweakColor.ShortDarkRed, ""));
                }
                else if (cth.Contains(TweakColor.ShortDarkYellow))
                {
                    Foreground = ConsoleColor.DarkYellow;
                    Console.Write(cth.Replace(TweakColor.ShortDarkYellow, ""));
                }
                else if (cth.Contains(TweakColor.ShortGray))
                {
                    Foreground = ConsoleColor.Gray;
                    Console.Write(cth.Replace(TweakColor.ShortGray, ""));
                }
                else if (cth.Contains(TweakColor.ShortGreen))
                {
                    Foreground = ConsoleColor.Green;
                    Console.Write(cth.Replace(TweakColor.ShortGreen, ""));
                }
                else if (cth.Contains(TweakColor.ShortMagenta))
                {
                    Foreground = ConsoleColor.Magenta;
                    Console.Write(cth.Replace(TweakColor.ShortMagenta, ""));
                }
                else if (cth.Contains(TweakColor.ShortRed))
                {
                    Foreground = ConsoleColor.Red;
                    Console.Write(cth.Replace(TweakColor.ShortRed, ""));
                }
                else if (cth.Contains(TweakColor.ShortWhite))
                {
                    Foreground = ConsoleColor.White;
                    Console.Write(cth.Replace(TweakColor.ShortWhite, ""));
                }
                else if (cth.Contains(TweakColor.ShortYellow))
                {
                    Foreground = ConsoleColor.Yellow;
                    Console.Write(cth.Replace(TweakColor.ShortYellow, ""));
                }
                else
                {
                    Foreground = defcol;
                    Console.Write(cth);
                }
            }
            Foreground = defcol;
        }

        public static void WriteLine(object value)
        {
            Write(value + "\n");
        }

        public static void Line()
        {
            lock (_locker)
                Console.WriteLine();
        }

        public static void WriteArray(Array array, string separator)
        {
            foreach(var obj in array)
            {
                Write(obj + separator);
            }
        }

        public static void WriteLineArray(Array array, string separator)
        {
            WriteArray(array, separator);
            Line();
        }
    }
}
