using System;

namespace Pacman
{
    public class ConsoleHelper
    {
        public static void WriteLine(ConsoleColor color, string text)
        {
            var previousColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ForegroundColor = previousColor;
        }

        public static void Write(ConsoleColor color, string text)
        {
            var previousColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Console.Write(text);

            Console.ForegroundColor = previousColor;
        }
    }
}