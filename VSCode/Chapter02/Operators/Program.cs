using System;
using static System.Console;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 3;
            WriteLine($"i = {i}");

            int x = 3;
            int y = x++;
            WriteLine($"x = {x}, y = {y}");

            WriteLine($"{11 + 3}");
            WriteLine($"{11 - 3}");
            WriteLine($"{11 * 3}");
            WriteLine($"{11 / 3}");
            WriteLine($"{11 % 3}");
            WriteLine($"{11.0 / 3}");
        }
    }
}
