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

        public int Count() => _cleanedSpots.Count();

        internal void AddMovement(Position currentPosition, Position previusPosition)
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
