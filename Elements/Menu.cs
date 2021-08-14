using ConsoleTweaks.Models;
using ConsoleTweaks.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleTweaks.Elements
{
    public class Menu
    {
        public static Menu SelectedMenu { get; set; }
        public MenuConfig Config { get; set; } = new MenuConfig();
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        private int? _selectedIndex;
        private string _selectedName;
        private bool close;
        private int currentItemIndex = 0;

        /// <summary>
        /// Menu items that can be modified
        /// </summary>
        public IReadOnlyList<MenuItem> Items => _menuItems;

        /// <summary>
        /// Selected menu item that can be modified
        /// </summary>
        public MenuItem SelectedItem
        {
            get => _menuItems[currentItemIndex];
            set => _menuItems[currentItemIndex] = value;
        }

        /// <summary>
        /// Creates Menu instance
        /// </summary>
        public Menu() { }
        public Menu(MenuConfig config) { if (Config == null) throw new ArgumentNullException("Config can't be a null"); Config = config; }
        public static Menu Configure(MenuConfig config)
        {
            return new Menu(config);
        }

        /// <summary>
        /// Close the menu before or after a menu action was triggered
        /// </summary>
        public void CloseMenu()
        {
            this.close = true;
            Console.CursorVisible = true;
            Console.Clear();
        }

        public Menu Add(string name, Action action)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            _menuItems.Add(new MenuItem(name, action, index: _menuItems.Count));
            return this;
        }

        public Menu Add(string name, Action<Menu> action)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (action is null)
                throw new ArgumentNullException(nameof(action));

            _menuItems.Add(new MenuItem(name, () => action(this), index: _menuItems.Count));
            return this;
        }
        public Menu Add(MenuItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _menuItems.Add(item);
            return this;
        }
        public Menu AddRange(List<MenuItem> menuItems)
        {
            if (menuItems == null)
                throw new ArgumentNullException(nameof(menuItems));

            foreach (var item in menuItems)
            {
                Add(item);
            }
            return this;
        }
        public Menu AddRange(IEnumerable<Tuple<string, Action>> menuItems)
        {
            if (menuItems == null)
                throw new ArgumentNullException(nameof(menuItems));

            foreach (var item in menuItems)
            {
                Add(item.Item1, item.Item2);
            }
            return this;
        }

        /// <summary>
        /// Don't run this method directly. Just pass a reference to this method.
        /// </summary>
        public static void Close() => throw new InvalidOperationException("Don't run this method directly. Just pass a reference to this method.");
        public static void Exit()
        {
            Environment.Exit(0);
        }

        public void Show()
        {
            if (SelectedMenu == null)
                SelectedMenu = this;
            else if (SelectedMenu != null && SelectedMenu != this)
            {
                SelectedMenu.CloseMenu();
                SelectedMenu = this;
            }
            Console.BackgroundColor = Config.Background;
            Console.ForegroundColor = Config.Foreground;
            Console.Clear();
            Console.CursorVisible = false;
            var selectedItem = GetSelectedItem();
            if (selectedItem != null)
            {
                selectedItem.Action.Invoke();
                return;
            }
            ConsoleKeyInfo key;
            bool[] visibility = CreateVisibility();
            var currentForegroundColor = Output.Foreground;
            var currentBackgroundColor = Output.Background;
            bool breakIteration = false;
            var filter = new StringBuilder();

            while (true)
            {
                Output.Cursor = Config.MenuPosition;
                Console.CursorVisible = false;
                do
                {
                    Output.Cursor = Config.MenuPosition;
                    Console.CursorVisible = false;
                redraw:
                    Output.Cursor = Config.MenuPosition;
                    Console.CursorVisible = false;
                    Config.WriteTitleAction(Config.Title);
                    Config.WriteHeaderAction(Config.Header);
                    int i = 0;
                    foreach (var menuItem in _menuItems)
                    {
                        if (Config.EnableFilter && !visibility[i])
                        {
                            currentItemIndex = SetAnotherCurItem(visibility, currentItemIndex, out var shouldRedraw);
                            if (shouldRedraw)
                            {
                                goto redraw;
                            }
                            i++;
                            continue;
                        }
                        if (currentItemIndex == i)
                        {
                            Output.Background = Config.SelectedBackground;
                            Output.Foreground = Config.SelectedForeground;
                            Output.Write(Config.Selector);
                            Config.WriteItemAction(menuItem);
                            Output.Line();
                            Output.Background = Config.Background;
                            Output.Foreground = Config.Foreground;
                        }
                        else
                        {
                            Output.Background = Config.Background;
                            Output.Foreground = Config.Foreground;
                            Output.Write(new string(' ', Config.Selector.Length));
                            Config.WriteItemAction(menuItem);
                            Output.Line();
                        }
                        i++;
                    }
                    Output.Cursor = Config.MenuPosition;
                    Console.CursorVisible = false;
                    if (breakIteration)
                    {
                        breakIteration = false;
                        Output.Cursor = Config.MenuPosition;
                        Console.CursorVisible = false;
                        break;
                    }

                    if (Config.EnableFilter)
                    {
                        Output.Cursor = Config.MenuPosition;
                        Console.CursorVisible = false;
                        Output.Write(Config.FilterPrompt + filter);
                    }

                readKey:
                    key = Console.ReadKey(true);
                    Output.Cursor = Config.MenuPosition;
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Config.PressEscapeAction?.Invoke();
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        currentItemIndex = IndexOfNextVisibleItem(currentItemIndex, visibility);
                        Output.Cursor = Config.MenuPosition;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        currentItemIndex = IndexOfPreviousVisibleItem(currentItemIndex, visibility);
                        Output.Cursor = Config.MenuPosition;
                    }
                    else if (key.KeyChar >= '0' && (key.KeyChar - '0') < _menuItems.Count)
                    {
                        currentItemIndex = key.KeyChar - '0';
                        breakIteration = true;
                    }
                    else if (key.Key != ConsoleKey.Enter)
                    {
                        if (Config.EnableFilter)
                        {
                            if (key.Key == ConsoleKey.Backspace)
                            {
                                if (filter.Length > 0)
                                {
                                    filter.Length--;
                                }
                            }
                            else if (!char.IsControl(key.KeyChar))
                            {
                                filter.Append(key.KeyChar);
                            }
                            UpdateVisibility(_menuItems, visibility,
                              (item) => item.Name.Contains(filter.ToString(), StringComparison.OrdinalIgnoreCase));
                        }
                        else
                        {
                            goto readKey;
                        }
                    }
                } while (key.Key != ConsoleKey.Enter);

                Output.Line();
                Output.Foreground = currentForegroundColor;
                Output.Background = currentBackgroundColor;
                var action = _menuItems[currentItemIndex].Action;
                if (action == Close)
                {
                    Console.Clear();
                    Console.CursorVisible = true;
                    return;
                }
                else
                {
                    action?.Invoke();
                    if (this.close)
                    {
                        this.close = false;
                        Console.CursorVisible = true;
                        return;
                    }
                }
            }
        }

        public MenuItem GetSelectedItem()
        {
            if (_selectedIndex.HasValue && _selectedIndex.Value < _menuItems.Count)
            {
                return _menuItems[_selectedIndex.Value];
            }
            if (_selectedName != null)
            {
                return _menuItems.Find(item => item.Name == _selectedName);
            }
            return null;
        }

        private int IndexOfNextVisibleItem(int curItem, bool[] visibility)
        {
            int idx = -1;
            if (curItem + 1 < visibility.Length)
            {
                idx = Array.IndexOf(visibility, value: true, startIndex: curItem + 1);
            }
            if (idx == -1)
            {
                idx = Array.IndexOf(visibility, value: true, startIndex: 0);
            }
            if (idx == -1)
            {
                idx = curItem;
            }
            return idx;
        }

        private int IndexOfPreviousVisibleItem(int curItem, bool[] visibility)
        {
            int idx = -1;
            if (curItem - 1 >= 0)
            {
                idx = Array.LastIndexOf(visibility, value: true, startIndex: curItem - 1);
            }
            if (idx == -1)
            {
                idx = Array.LastIndexOf(visibility, value: true, startIndex: visibility.Length - 1);
            }
            if (idx == -1)
            {
                idx = curItem;
            }
            return idx;
        }

        private static int SetAnotherCurItem(bool[] visibility, int curItem, out bool shouldRedraw)
        {
            shouldRedraw = false;
            var foundIdx = Array.IndexOf(visibility, true, curItem);
            if (foundIdx != -1)
            {
                return foundIdx;
            }
            foundIdx = Array.LastIndexOf(visibility, true, curItem);
            if (foundIdx != -1)
            {
                shouldRedraw = true;
                return foundIdx;
            }
            return foundIdx == -1 ? 0 : foundIdx;
        }

        private bool[] CreateVisibility()
        {
            bool[] visibility = new bool[_menuItems.Count];
            for (int i = 0; i < visibility.Length; i++)
            {
                visibility[i] = true;
            }
            return visibility;
        }

        private static void UpdateVisibility<T>(List<T> items, bool[] visibility, Predicate<T> matchFilter)
        {
            for (int i = 0; i < visibility.Length; i++)
            {
                visibility[i] = matchFilter(items[i]);
            }
        }
    }
}
