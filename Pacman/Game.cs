using System;
using System.Collections.Generic;
using System.Linq;

namespace Pacman
{
    public class Game : IConsoleDisplayer
    {
        public const int Columns = 10;
        public const int Rows = 10;

        public bool GameOver { get; private set; } = false;

        public Field[,] Fields { get; } = new Field[Rows, Columns];
        public List<Ghost> Ghosts { get; } = new List<Ghost>();

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
            if (GameOver) return;

            Pacman.Move();
            Pacman.CollectCoins();
            

            foreach (var ghost in Ghosts)
            {
                if (ghost.Position.X == Pacman.Position.X && ghost.Position.Y == Pacman.Position.Y)
                {
                    GameOver = true;
                    break;
                }

                ghost.Move();

                if (ghost.Position.X == Pacman.Position.X && ghost.Position.Y == Pacman.Position.Y)
                {
                    GameOver = true;
                    break;
                }
            }

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
                    if (Ghosts.Any(x => x.Position.X == column && x.Position.Y == row))
                    {
                        var ghost = Ghosts.First(x => x.Position.X == column && x.Position.Y == row);
                        ghost.Display();
                        continue;
                    }

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