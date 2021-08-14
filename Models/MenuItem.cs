using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTweaks.Models
{
    public sealed class MenuItem
    {
        public string Name { get; set; }
        public Action Action { get; set; }
        public int Index { get; }

        internal MenuItem(string name, Action action, int index)
        {
            Name = name;
            Action = action;
            Index = index;
        }
    }
}
