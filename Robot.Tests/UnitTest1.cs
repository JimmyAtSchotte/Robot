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

        internal void Move(string v)
        {
            _position.Y += 1;
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

        [Test]
        public void MoveRobotNorth1Step()
        {
            var robot = new Robot();
            robot.Move("N 1");

            Assert.AreEqual(1, robot.GetPosition().Y);
        }
    }
}