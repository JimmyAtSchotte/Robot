using System;
using System.Collections.Generic;
using System.Linq;

namespace Robot.Tests
{
    public class Robot
    {
        private readonly List<Position> _positions;

        public Robot()
        {
            _positions = new List<Position>()
            {
                new Position(0, 0)
            };
        }

        internal Position Move(string movement)
        {
            var direction = movement[0];
            var steps = Convert.ToInt32(movement.Substring(2));

            var position = direction switch
            {
                'N' => _positions.Last().MoveY(steps),
                'S' => _positions.Last().MoveY(steps * -1),
                'W' => _positions.Last().MoveX(steps * -1),
                'E' => _positions.Last().MoveX(steps)
            };

            _positions.Add(position);

            return position;
        }

        internal int CalculateCleanedSpots()
        {
            var cleanedSpots = new CleanedSpots();

            for (int i = 0; i < _positions.Count; i++)
            {
                var currentPosition = _positions[i];
                var previusPosition = i > 0 ? _positions[i - 1] : null;

                cleanedSpots.AddMovement(currentPosition, previusPosition);     
            }

            return cleanedSpots.Count();
        }
    }
}
