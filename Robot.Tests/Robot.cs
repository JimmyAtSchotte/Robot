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

        internal int CalculateCleanedSpots()
        {
            var cleanedSpots = new CleanedSpots();  
            return cleanedSpots.CalculateCleanedSpots(_positions.ToArray());
        }

        public Position Move(IMoveCommand moveCommand)
        {
            var position = _positions.Last().Move(moveCommand);
            _positions.Add(position);
            return position;
        }
    }
}
