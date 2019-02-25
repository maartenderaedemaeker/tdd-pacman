using System;

namespace Pacman
{
    public class Field : IConsoleDisplayer
    {
        public void Display()
        {
            ConsoleHelper.Write(ConsoleColor.DarkGray, ". ");
        }
    }
}