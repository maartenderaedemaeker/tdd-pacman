using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            const int gametickDelayMiliseconds = 600;

            var exitRequested = false;
            var gamestarted = false;
            System.Console.CancelKeyPress += (sender, eventArgs) =>
            {
                exitRequested = true;
                System.Console.WriteLine("Exit requested");
            };

            foreach (var field in game.Fields)
            {
                field.HasCoin = true;
            }

            Task.Factory.StartNew(() =>
            {
                while (!exitRequested)
                {
                    var key = System.Console.ReadKey(true);

                    gamestarted = true;

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            game.ChangeDirection(Direction.Up);
                            break;

                        case ConsoleKey.DownArrow:
                            game.ChangeDirection(Direction.Down);
                            break;

                        case ConsoleKey.RightArrow:
                            game.ChangeDirection(Direction.Right);
                            break;

                        case ConsoleKey.LeftArrow:
                            game.ChangeDirection(Direction.Left);
                            break;
                    }
                }
            });

            while (!exitRequested)
            {
                System.Console.Clear();

                if (gamestarted)
                {
                    game.Tick();
                }

                game.Display();
                Thread.Sleep(gametickDelayMiliseconds);
            }
        }
    }
}
