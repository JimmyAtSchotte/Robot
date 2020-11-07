using System;
using System.Collections.Generic;
using System.Linq;

namespace Robot.Tests
{
    public class CleanedSpots
    {
        private readonly List<CleanedSpot> _cleanedSpots;

        public CleanedSpots()
        {
            _cleanedSpots = new List<CleanedSpot>();
        }

        private void Add(int x, int y)
        {
            if (_cleanedSpots.Any(spot => spot.X == x && spot.Y == y))
                return;

            _cleanedSpots.Add(new CleanedSpot(x, y));
        }

        public int CalculateCleanedSpots(Position[] positions)
        {
            for (int i = 0; i < positions.Count(); i++)
            {
                var currentPosition = positions[i];
                var previusPosition = i > 0 ? positions[i - 1] : null;

                AddMovement(currentPosition, previusPosition);
            }

            return _cleanedSpots.Count();
        }

        private void AddMovement(Position currentPosition, Position previusPosition)
        {
            Add(currentPosition.X, currentPosition.Y);

            if (previusPosition is null)
                return;

            AddHorizontalMovement(currentPosition, previusPosition);
            AddVerticalMovement(currentPosition, previusPosition);            
        }

        private void AddHorizontalMovement(Position currentPosition, Position previusPosition)
        {
            if (currentPosition.X == previusPosition.X)
                return;

            var start = Math.Min(currentPosition.X, previusPosition.X);
            var stop = Math.Max(currentPosition.X, previusPosition.X);

            for (int x = start; x < stop; x++)
                Add(x, currentPosition.Y);
        }

        private void AddVerticalMovement(Position currentPosition, Position previusPosition)
        {
            if (currentPosition.Y == previusPosition.Y)
                return;

            var start = Math.Min(currentPosition.Y, previusPosition.Y);
            var stop = Math.Max(currentPosition.Y, previusPosition.Y);

            for (int y = start; y < stop; y++)
                Add(currentPosition.X, y);
        }
    }
}
