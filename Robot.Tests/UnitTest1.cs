using NUnit.Framework;
using System;

namespace Robot.Tests
{
    public class Robot
    {
        internal void Move(string v)
        {
            
        }
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
    }
}