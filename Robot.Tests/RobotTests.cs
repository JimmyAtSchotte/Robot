using NUnit.Framework;

namespace Robot.Tests
{
    public class RobotTests
    {                 
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotNorthNStep(int steps)
        {
            var robot = new Robot();
            var position = robot.Move($"N {steps}");

            Assert.AreEqual(steps, position.Y);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotSouthNStep(int steps)
        {
            var robot = new Robot();
            var position = robot.Move($"S {steps}");

            Assert.AreEqual(steps * -1, position.Y);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotWestNStep(int steps)
        {
            var robot = new Robot();
            var position = robot.Move($"W {steps}");

            Assert.AreEqual(steps * -1, position.X);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotEastNStep(int steps)
        {
            var robot = new Robot();
            var position = robot.Move($"E {steps}");

            Assert.AreEqual(steps, position.X);
        }

        [Test]
        public void ShouldMoveRobotInMultipleDirections()
        {
            var robot = new Robot();
            robot.Move("N 1");
            robot.Move("E 3");
            robot.Move("S 4");
            var position = robot.Move("W 1");

            Assert.AreEqual(-3, position.Y);
            Assert.AreEqual(2, position.X);
        }

        [Test]
        public void ShouldHaveCleanedASpotWithoutAnyMovement()
        {
            var robot = new Robot();

            Assert.AreEqual(1, robot.CalculateCleanedSpots());
        }
 
        [TestCase("N 5")]
        [TestCase("S 5")]
        [TestCase("E 5")]
        [TestCase("W 5")]
        public void ShouldHaveCleanedSpotsInOneDirection(string movement)
        {
            var robot = new Robot();
            robot.Move(movement);

            Assert.AreEqual(6, robot.CalculateCleanedSpots());
        }




    
    }
}
