using ConsoleTweaks.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTweaks.Models
{
    public class MenuConfig
    {
        /// <summary>
        /// Selected background color
        /// </summary>
        public ConsoleColor SelectedBackground = Console.ForegroundColor;

        /// <summary>Selected foreground color</summary>
        public ConsoleColor SelectedForeground = Console.BackgroundColor;

        /// <summary>Background color</summary>
        public ConsoleColor Background = Console.BackgroundColor;

        /// <summary>Foreground color</summary>
        public ConsoleColor Foreground = Console.ForegroundColor;
        /// <summary>Action invoke when you press esc</summary>
        public Action PressEscapeAction = null;

        /// <summary>Menu header</summary>
        public string Header = "";
        /// <summary>Header write action</summary>
        public Action<string> WriteHeaderAction = header => Output.WriteLine(header);

        /// <summary>Displaying an item in the menu</summary>
        public Action<MenuItem> WriteItemAction = item => Output.Write($"{item.Index}. {item.Name}");

        /// <summary>Displaying a selector</summary>
        public string Selector = "> ";

        /// <summary>Filter prompt</summary>
        public string FilterPrompt = "Filter: ";

        /// <summary>Clear console</summary>
        public Point MenuPosition = new Point(0,0);

        /// <summary>Filter state</summary>
        public bool EnableFilter = false;

        /// <summary>Menu title</summary>
        public string Title = "";

        /// <summary>Write title action</summary>
        public Action<string> WriteTitleAction = title => Output.WriteLine(title);
    }
}
