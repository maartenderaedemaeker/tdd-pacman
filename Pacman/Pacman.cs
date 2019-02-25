using System;

namespace Pacman
{
    public class Pacman : IConsoleDisplayer
    {
        public Position Position { get; set;  }
        public Direction Direction { get; set; }

        public Pacman(Position position, Direction startDirection)
        {
            Position = position;
            Direction = startDirection;
        }

        public void Display()
        {
            switch (Direction)
            {
                case Direction.Up:
                    ConsoleHelper.Write(ConsoleColor.Yellow, "v ");
                    break;
                case Direction.Right:
                    ConsoleHelper.Write(ConsoleColor.Yellow, "< ");
                    break;
                case Direction.Down:
                    ConsoleHelper.Write(ConsoleColor.Yellow, "^ ");
                    break;
                case Direction.Left:
                    ConsoleHelper.Write(ConsoleColor.Yellow, "> ");
                    break;
            }
        }
    }
}