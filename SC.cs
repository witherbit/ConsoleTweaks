using ConsoleTweaks.Abstract;
using ConsoleTweaks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTweaks
{
    /// <summary>
    /// Short console method invoke
    /// </summary>
    public static class SC
    {
        public static Point Cursor
        {
            get => Output.Cursor;
            set => Output.Cursor = value;
        }
        public static ConsoleColor Foreground
        {
            get
            {
                return Output.Foreground;
            }
            set
            {
                Output.Foreground = value;
            }
        }
        public static ConsoleColor Background
        {
            get
            {
                return Output.Background;
            }
            set
            {
                Output.Background = value;
            }
        }
        public static void SetCursorPosition(this Point point)
        {
            Cursor = point;
        }
        public static void SetForegroundColor(this ConsoleColor color)
        {
            Foreground = color;
        }
        public static void SetBackgroundColor(this ConsoleColor color)
        {
            Background = color;
        }
        public static void Write(this object data)
        {
            Output.Write(data);
        }
        public static void WriteLine(this object data)
        {
            if (data == null)
            {
                Console.WriteLine();
                return;
            }
            Output.WriteLine(data);
        }
        public static void WriteLine()
        {
            Console.WriteLine();
        }
        public static void WriteArray(this Array array, string separator, bool newLine = false)
        {
            Output.WriteArray(array, separator);
            if (newLine) Console.WriteLine();
        }
        public static string Read(ConsoleColor readColor = ConsoleColor.White)
        {
            return Input.Read();
        }
        public static string ReadAfterWriteLine(this object value, ConsoleColor readColor = ConsoleColor.White)
        {
            return Input.ReadAfterWriteLine(value, readColor);
        }
        public static string ReadAfterWrite(this object value, ConsoleColor readColor = ConsoleColor.White)
        {
            return Input.ReadAfterWrite(value, readColor);
        }
        public static bool Confirm(this string confirmText, ConsoleKey acceptKey = ConsoleKey.Y, ConsoleKey deniedKey = ConsoleKey.N)
        {
            return Input.Confirm(confirmText, acceptKey, deniedKey);
        }
        public static ConsoleKey WaitKey()
        {
            return Input.WaitKey();
        }
    }
}
