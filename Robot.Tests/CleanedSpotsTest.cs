using NUnit.Framework;
using Robot.Simulator.Robot;

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
            var previousPosition = new Position(0, 0);
            var currentPosition = new Position(x, y);

            var result  =cleanedSpots.CalculateCleanedSpots(new[] { currentPosition, previousPosition });

            Assert.AreEqual(3, result);
        }

             
        
        [Test]
        public void ShouldCountUniqueSpotsMovingVertical()
        {
            var cleanedSpots = new CleanedSpots();

            var result =  cleanedSpots.CalculateCleanedSpots(new[] { 
                new Position(0, 0),
                new Position(10, 0),
                new Position(0, 0)
            });

            Assert.AreEqual(11, result);
        }

        
        [Test]
        public void ShouldCountUniqueSpotsMovingHorizontal()
        {
            var cleanedSpots = new CleanedSpots();

            var result =  cleanedSpots.CalculateCleanedSpots(new[] { 
                new Position(0, 0),
                new Position(0, 10),
                new Position(0, 0)
            });

            Assert.AreEqual(11, result);
        }
    }
}
