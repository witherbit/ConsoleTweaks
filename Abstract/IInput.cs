using ConsoleTweaks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTweaks.Abstract
{
    public interface IInput
    {
        Point Cursor { get; set; }
        ConsoleColor Foreground { get; set; }
        ConsoleColor Background { get; set; }
        string ReadAfterWrite(object value, ConsoleColor readColor = ConsoleColor.White);
        string ReadAfterWriteLine(object value, ConsoleColor readColor = ConsoleColor.White);
        string Read(ConsoleColor readColor = ConsoleColor.White);
        bool Confirm(string confirmText, ConsoleColor confirmColor = ConsoleColor.White, ConsoleKey acceptKey = ConsoleKey.Y, ConsoleKey deniedKey = ConsoleKey.N);
        ConsoleKey WaitKey();
    }
}
