using NUnit.Framework;

namespace Robot.Tests
{
    public class Tests
    {
        [Test]
        public void CreateRobot()
        {
            var robot = new Robot();
        }

        [Test]
        public void MoveRobot()
        {
            var robot = new Robot();
            robot.Move("N 1");
        }
          

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
    }
}
