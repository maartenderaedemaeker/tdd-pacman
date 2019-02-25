using System;

namespace Pacman
{
    public class Ghost : IConsoleDisplayer
    {
        private readonly IRandomDirectionHelper _randomDirectionHelper;
        public Position Position { get; set; }

        public Ghost(IRandomDirectionHelper randomDirectionHelper)
        {
            _randomDirectionHelper = randomDirectionHelper;
        }

        public void Display()
        {
            ConsoleHelper.Write(ConsoleColor.DarkBlue, "& ");
        }

        public void Move()
        {
            var direction = _randomDirectionHelper.GetDirection();

            if (direction == Direction.Right && Position.X < Game.Columns - 1)
            {
                Position = new Position(Position.X + 1, Position.Y);
            }

            if (direction == Direction.Left && Position.X > 0)
            {
                Position = new Position(Position.X - 1, Position.Y);
            }

            if (direction == Direction.Up && Position.Y > 0)
            {
                Position = new Position(Position.X, Position.Y - 1);
            }

            if (direction == Direction.Down && Position.Y < Game.Rows - 1)
            {
                Position = new Position(Position.X, Position.Y + 1);
            }
        }
    }
}