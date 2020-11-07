using NUnit.Framework;
using Robot.Simulator.Robot;

namespace Robot.Tests
{
    [TestFixture]
    public class PositionTest
    {
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MovePositionNorthNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var position = startPosition.Move(MoveCommand.Parse($"N {steps}"));

            Assert.AreEqual(steps, position.Y);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MovePositionSouthNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var position = startPosition.Move(MoveCommand.Parse($"S {steps}"));

            Assert.AreEqual(steps * -1, position.Y);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MovePositionWestNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var position = startPosition.Move(MoveCommand.Parse($"W {steps}"));

            Assert.AreEqual(steps * -1, position.X);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MovePositionEastNStep(int steps)
        {
            var startPosition = new Position(0, 0);
            var position = startPosition.Move(MoveCommand.Parse($"E {steps}"));

            Assert.AreEqual(steps, position.X);
        }
    }
}
