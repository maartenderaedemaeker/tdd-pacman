using System;

namespace Pacman
{
    public interface IRandomDirectionHelper
    {
        Direction GetDirection();
    }

    public class RandomDirectionHelper : IRandomDirectionHelper
    {
        private Random Random { get; } = new Random();

        public Direction GetDirection()
        {
            return (Direction) Random.Next(4);
        }
    }
}