using System.Collections.Generic;
using System.Linq;

namespace Pacman.Test.Helpers
{
    public class FakeRandomDirections : IRandomDirectionHelper
    {
        private readonly List<Direction> _directions;
        private int Counter { get; set; } = 0;

        public FakeRandomDirections(params Direction[] directions)
        {
            _directions = directions.ToList();
        }

        public Direction GetDirection()
        {
            var index = Counter % _directions.Count;
            var direction = _directions[index];
            Counter++;
            return direction;
        }
    }
}