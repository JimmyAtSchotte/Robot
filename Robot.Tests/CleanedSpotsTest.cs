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


            var result = cleanedSpots.CalculateCleanedSpots(new[] { currentPosition });

            Assert.AreEqual(1, result);
        }
          

        [TestCase(2, 0)]
        [TestCase(-2, 0)]
        [TestCase(0, 2)]
        [TestCase(0, -2)]
        public void ComparePositionsToAddCleanedSpots(int x, int y)
        {
            var cleanedSpots = new CleanedSpots();
            var previusPosition = new Position(0, 0);
            var currentPosition = new Position(x, y);

            var result  =cleanedSpots.CalculateCleanedSpots(new[] { currentPosition, previusPosition });

            Assert.AreEqual(3, result);
        }

        [Test]
        public void ShouldNotCountSameSpotTwice()
        {
            var cleanedSpots = new CleanedSpots();
            var previusPosition = new Position(0, 0);
            var currentPosition = new Position(0, 0);

            var result =  cleanedSpots.CalculateCleanedSpots(new[] { currentPosition, previusPosition });

            Assert.AreEqual(1, result);
        }

    }
}
