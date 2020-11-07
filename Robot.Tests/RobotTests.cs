using NUnit.Framework;
using Robot.Simulator.Robot;

namespace Robot.Tests
{

    public class RobotTests
    {                 
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotNorthNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var robot = new Simulator.Robot.Robot(null, startPosition);
            var position = robot.Move(MoveCommand.Parse($"N {steps}"));

            Assert.AreEqual(steps, position.Y);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotSouthNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var robot = new Simulator.Robot.Robot(null, startPosition);
            var position = robot.Move(MoveCommand.Parse($"S {steps}"));

            Assert.AreEqual(steps * -1, position.Y);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotWestNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var robot = new Simulator.Robot.Robot(null, startPosition);
            var position = robot.Move(MoveCommand.Parse($"W {steps}"));

            Assert.AreEqual(steps * -1, position.X);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotEastNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var robot = new Simulator.Robot.Robot(null, startPosition);
            var position = robot.Move(MoveCommand.Parse($"E {steps}"));

            Assert.AreEqual(steps, position.X);
        }

        [Test]
        public void ShouldMoveRobotInMultipleDirections()
        {
            var startPosition = new Position(0, 0);
            var robot = new Simulator.Robot.Robot(null, startPosition);
            robot.Move(MoveCommand.Parse("N 1"));
            robot.Move(MoveCommand.Parse("E 3"));
            robot.Move(MoveCommand.Parse("S 4"));
            var position = robot.Move(MoveCommand.Parse("W 1"));

            Assert.AreEqual(-3, position.Y);
            Assert.AreEqual(2, position.X);
        }

        [Test]
        public void ShouldHaveCleanedASpotWithoutAnyMovement()
        {
            var startPosition = new Position(0, 0);
            var robot = new Simulator.Robot.Robot(new CleanedSpots(), startPosition);

            Assert.AreEqual(1, robot.CalculateCleanedSpots());
        }
 
        [TestCase("N 5")]
        [TestCase("S 5")]
        [TestCase("E 5")]
        [TestCase("W 5")]
        public void ShouldHaveCleanedSpotsInOneDirection(string movement)
        {
            var startPosition = new Position(0, 0);
            var robot = new Simulator.Robot.Robot(new CleanedSpots(), startPosition);
            robot.Move(MoveCommand.Parse(movement));

            Assert.AreEqual(6, robot.CalculateCleanedSpots());
        }    
    }
}
