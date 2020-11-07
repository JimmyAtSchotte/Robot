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
            var position = moveCommand.Direction switch
            {
                Direction.North => _positions.Last().MoveY(moveCommand.Steps),
                Direction.South => _positions.Last().MoveY(moveCommand.Steps * -1),
                Direction.West => _positions.Last().MoveX(moveCommand.Steps * -1),
                Direction.East => _positions.Last().MoveX(moveCommand.Steps)
            };

            _positions.Add(position);

            return position;
        }
    }
}
