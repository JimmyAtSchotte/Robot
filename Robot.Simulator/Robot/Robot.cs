using System.Collections.Generic;
using System.Linq;
using Robot.Simulator.Core;

namespace Robot.Simulator.Robot
{
    public class Robot
    {
        private readonly List<Position> _positions;
        private readonly ICleanedSpots _cleanedSpots;
        
        public Robot(ICleanedSpots cleanedSpots, Position startPosition)
        {
            _cleanedSpots = cleanedSpots;
            _positions = new List<Position>()
            {
                startPosition
            };
        }

        public int CalculateCleanedSpots()
        {
            return _cleanedSpots.CalculateCleanedSpots(_positions.ToArray());
        }

        public Position Move(IMoveCommand moveCommand)
        {
            var position = _positions.Last().Move(moveCommand);
            _positions.Add(position);
            return position;
        }
    }
}
