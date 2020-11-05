using NUnit.Framework;

namespace Robot.Tests
{
    [TestFixture]
    public class CleanedSpotsTest
    {
        [Test]
        public void InitialMovement()
        {
            var cleanedSpots = new CleanedSpots();
            var currentPosition = new Position(0, 0);

            cleanedSpots.AddMovement(currentPosition, null);

            Assert.AreEqual(1, cleanedSpots.Count());
        }

        [Test]
        public void Compare()
        {
            var cleanedSpots = new CleanedSpots();
            var previusPosition = new Position(0, 0);
            var currentPosition = new Position(1, 0);

            cleanedSpots.AddMovement(currentPosition, previusPosition);

            Assert.AreEqual(2, cleanedSpots.Count());
        }


        [TestCase(1, 0)]
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, -1)]
        public void ComparePositionsToAddCleanedSpots(int x, int y)
        {
            var cleanedSpots = new CleanedSpots();
            var previusPosition = new Position(0, 0);
            var currentPosition = new Position(x, y);

            cleanedSpots.AddMovement(currentPosition, previusPosition);

            Assert.AreEqual(2, cleanedSpots.Count());
        }

        [Test]
        public void ShouldNotCountSameSpotTwice()
        {
            var cleanedSpots = new CleanedSpots();
            var previusPosition = new Position(0, 0);
            var currentPosition = new Position(0, 0);

            cleanedSpots.AddMovement(currentPosition, previusPosition);

            Assert.AreEqual(1, cleanedSpots.Count());
        }

    }
}
