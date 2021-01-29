# ConsoleTweaks
## Docs
### Standart methods
**You can use Write() to output data in the console**
```c#
  Tweak.Write("Hello green world!");
```
**You can also assign a color to each character or passage**
```c#
  Tweak.Write("~r~Hello ~g~green ~db~world!");
```
![Alt-colored out](https://sun9-24.userapi.com/impg/8xecKOzTmKUyKUruOfOODpPmg1f2-pCGJ6IkCw/zdzq6Ja6ZLg.jpg?size=961x485&quality=96&proxy=1&sign=12c5220b07136c4b8948445942dd483c&type=album "Орк")
**You can also set the color using TweakColor**
```c#
  Tweak.Write($"{TweakColor.Yellow}Hello {TweakColor.Cyan}green {TweakColor.Magenta}world!");
```
![Alt-colored out](https://sun9-23.userapi.com/impg/5qtNrB0wKYPYvUmaeo-otREJBR74kDICWLUMsQ/RzC3Yv59hCQ.jpg?size=953x470&quality=96&proxy=1&sign=2c4b512d91dfab060a3ee3a99d08bf47&type=album "Орк")
**You can also use WriteLine in the same way**
```c#
  Tweak.WriteLine($"~r~first line before second line");
  Tweak.WriteLine($"~y~second line after first line");
```
![Alt-colored out](https://sun9-67.userapi.com/impg/_1J-MEs0EPyqohdQnmfgZYUgDxENpwO6Sh1e1Q/O083_u5zuyA.jpg?size=955x477&quality=96&proxy=1&sign=7a8a68c34abeb6ea03a549b207c8f5cd&type=album "Орк")
**The array elements are output to the console using the WriteArray and WriteLineArray methods**
```c#
  string text = "hello;world;!";
  string[] strings = text.Split(new char[] { ';' });
  Tweak.WriteLineArray(strings, " ");
```
![Alt-colored out](https://sun9-14.userapi.com/impg/qSwNzEyVPPpsWfT-rloyyk_fy6iGdH-SwjL4oA/Qw41Y-6XKic.jpg?size=950x471&quality=96&proxy=1&sign=5920148e23d86d6cbc5fc7b8eb4d916c&type=album "Орк")
**You can quickly read the incoming values with output to the console**
```c#
  Tweak.WriteLine(Tweak.ReadAfterWrite("~c~How you doing? >: ", ConsoleColor.Yellow));
```
![Alt-colored out](https://sun9-49.userapi.com/impg/FkKxoFgsoRhzEHhM4Udjt0scltPz-U-O_kACiQ/O13CNMAyQxo.jpg?size=903x457&quality=96&proxy=1&sign=405236e2dcc4432411f8b252dbe6bb0b&type=album "Орк")

### Colors
- Black = ~d~
- DarkBlue = ~db~
- DarkGreen = ~dg~
- DarkCyan = ~dc~
- DarkRed = ~dr~
- DarkMagenta = ~dm~
- DarkYellow = ~dy~
- DarkGray = ~dge~
- Gray = ~ge~
- Red = ~r~
- Green = ~g~
- Blue = ~b~
- Cyan = ~c~
- Magenta = ~m~
- Yellow = ~y~
- White = ~w~
