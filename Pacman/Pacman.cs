using System;

namespace Pacman
{
    public class Pacman : IConsoleDisplayer
    {
        public Position Position { get; set;  }
        public Direction Direction { get; set; }
        public Game Game { get; }

        public Pacman(Position position, Direction startDirection, Game game)
        {
            Position = position;
            Direction = startDirection;
            Game = game;
        }

        public void Move()
        {
            if (Direction == Direction.Right && Position.X < Game.Columns - 1)
            {
                Position = new Position(Position.X  + 1, Position.Y);
            }

            if (Direction == Direction.Left && Position.X > 0)
            {
                Position = new Position(Position.X - 1, Position.Y);
            }

            if (Direction == Direction.Up && Position.Y > 0)
            {
                Position = new Position(Position.X, Position.Y - 1);
            }

            if (Direction == Direction.Down && Position.Y < Game.Rows - 1)
            {
                Position = new Position(Position.X, Position.Y + 1);
            }
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