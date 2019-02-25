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
                ConsoleHelper.Write(ConsoleColor.DarkYellow, "* ");
                return;
            }

            ConsoleHelper.Write(ConsoleColor.DarkGray, ". ");
        }
    }
}