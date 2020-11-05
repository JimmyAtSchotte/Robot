using NUnit.Framework;

namespace Robot.Tests
{
    public class Tests
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
        public void ShouldHaveCleanedASpot()
        {
            var robot = new Robot();

            Assert.AreEqual(1, robot.CleanedSpots());
        }      
        
    }
}
