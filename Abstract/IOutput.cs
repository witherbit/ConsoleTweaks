using ConsoleTweaks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTweaks.Abstract
{
    interface IOutput
    {
        Point Cursor { get; set; }
        ConsoleColor Foreground { get; set; }
        ConsoleColor Background { get; set; }
        void Write(object value);
        void WriteLine(object value);
        void Line();
        void WriteArray(Array array, string separator);
        void WriteLineArray(Array array, string separator);
    }
}
