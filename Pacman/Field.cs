using System;

namespace Pacman
{
    public class Field : IConsoleDisplayer
    {
        public bool HasCoin { get; set; }

        public void Display()
        {
            if (HasCoin)
            {
                ConsoleHelper.Write(ConsoleColor.DarkMagenta, "* ");
                return;
            }

            ConsoleHelper.Write(ConsoleColor.DarkGray, ". ");
        }
    }
}