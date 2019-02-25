using System;

namespace Pacman
{
    public class Game : IConsoleDisplayer
    {
        public const int Columns = 10;
        public const int Rows = 10;

        public Field[,] Fields { get; } = new Field[Rows, Columns];

        public Pacman Pacman { get; }

        public Game()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    Fields[row, column] = new Field();
                }
            }

            Pacman = new Pacman(new Position(Rows / 2, Columns / 2), Direction.Right, this);
        }
        public void Tick()
        {
            Pacman.Move();
        }

        public void ChangeDirection(Direction direction)
        {
            Pacman.Direction = direction;
        }

        public void Display()
        {
            DisplayHeader();
            DisplayBoard();
            DisplayFooter();
        }

        private void DisplayHeader()
        {
            ConsoleHelper.WriteLine(ConsoleColor.Yellow, "Pacman");
            ConsoleHelper.WriteLine(ConsoleColor.DarkRed, $"Score: {Pacman.Score}");
            ConsoleHelper.WriteLine(ConsoleColor.DarkBlue, new string('-', 20));
        }

        private static void DisplayFooter()
        {
            ConsoleHelper.WriteLine(ConsoleColor.DarkBlue, new string('-', 20));
        }

        private void DisplayBoard()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    if (Pacman.Position.Y == row && Pacman.Position.X == column)
                    {
                        Pacman.Display();
                        continue;
                    }

                    Fields[row, column].Display();
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}