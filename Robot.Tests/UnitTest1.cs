using NUnit.Framework;
using System;

namespace Robot.Tests
{
    public class Robot
    {
        private readonly Position _position;

        public Robot()
        {
            _position = new Position();
        }

        internal void Move(string movement)
        {
            var direction = movement[0];
            var steps = Convert.ToInt32(movement.Substring(2));

            switch (direction)
            {
                case 'N': 
                    _position.Y += steps; 
                    break;
                case 'S':
                    _position.Y -= steps;
                    break;

                default:
                    break;
            }

        }

        internal Position GetPosition()
        {
            return _position;
        }
    }

    public class Position
    {
        public int Y { get; set; }
        public int X { get; set; }
    }


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
            robot.Move($"N {steps}");

            Assert.AreEqual(steps, robot.GetPosition().Y);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(100)]
        public void MoveRobotSouthNStep(int steps)
        {
            var robot = new Robot();
            robot.Move($"S {steps}");

            Assert.AreEqual(steps * -1, robot.GetPosition().Y);
        }
    }
}