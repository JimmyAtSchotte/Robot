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

            if (currentPosition.X > previusPosition.X)
                for (int x = previusPosition.X; x < currentPosition.X - previusPosition.X; x++)
                   Add(x, currentPosition.Y);

            if (previusPosition.X > currentPosition.X)
                for (int x = previusPosition.X; x > currentPosition.X - previusPosition.X; x--)
                    Add(x, currentPosition.Y);

            if (currentPosition.Y > previusPosition.Y)
                for (int y = previusPosition.Y; y < currentPosition.Y - previusPosition.Y; y++)
                    Add(currentPosition.X, y);

            if (previusPosition.Y > currentPosition.Y)
                for (int y = previusPosition.Y; y > currentPosition.Y - previusPosition.Y; y--)
                    Add(currentPosition.X, y);
        }
    }
}
