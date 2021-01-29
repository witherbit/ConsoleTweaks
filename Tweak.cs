
namespace System
{
    public sealed class Tweak
    {
        public static Position Cursor
        {
            get
            {
                return new Position(Console.CursorTop, Console.CursorLeft);
            }
            set
            {
                Console.SetCursorPosition(value.Left, value.Top);
            }
        }

        public static ConsoleColor Color
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

        public static void Write(object value)
        {
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
                .Replace($"{TweakColor.Magenta}", $"{TweakColor.Magenta}{TweakColor.ShortMagenta}")
                ;
        }

        public static void WriteLine(object value)
        {

        }

        public static void WriteArray(Array array, string separator)
        {
            foreach(var obj in array)
            {
                Write(obj + separator);
            }
        }
    }
}
