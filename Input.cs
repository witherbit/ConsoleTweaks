using ConsoleTweaks.Abstract;
using ConsoleTweaks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTweaks
{
    public static class Input
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
        public static string ReadAfterWrite(object value, ConsoleColor readColor = ConsoleColor.White)
        {
            var defcol = Output.Foreground;
            Output.Write(value);
            Output.Foreground = readColor;
            lock (Output._locker)
            {
                string ret = Console.ReadLine();
                Output.Foreground = defcol;
                return ret;
            }
        }
        public static string ReadAfterWriteLine(object value, ConsoleColor readColor = ConsoleColor.White)
        {
            var defcol = Output.Foreground;
            Output.WriteLine(value);
            Output.Foreground = readColor;
            lock (Output._locker)
            {
                string ret = Console.ReadLine();
                Output.Foreground = defcol;
                return ret;
            }
        }
        public static string Read(ConsoleColor readColor = ConsoleColor.White)
        {
            var defcol = Output.Foreground;
            Output.Foreground = readColor;
            lock (Output._locker)
            {
                string ret = Console.ReadLine();
                Output.Foreground = defcol;
                return ret;
            }
        }
        public static bool Confirm(string confirmText, ConsoleKey acceptKey = ConsoleKey.Y, ConsoleKey deniedKey = ConsoleKey.N)
        {
            Output.WriteLine(confirmText);
            lock(Output._locker)
            while (true)
            {
                ConsoleKey inputKey = WaitKey();
                if (inputKey == acceptKey)
                    return true;
                else if (inputKey == deniedKey) 
                    return false;
            }
        }
        public static ConsoleKey WaitKey()
        {
            return Console.ReadKey(true).Key;
        }
    }
}
