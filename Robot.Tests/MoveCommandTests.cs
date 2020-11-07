using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace Robot.Tests
{
    [TestFixture]
    public class MoveCommandTests
    {
        [Test]
        public void ParseNorthMovement()
        {
            var moveCommand = MoveCommand.Parse("N 1");

            Assert.AreEqual(Direction.North, moveCommand.Direction);
        }

        [Test]
        public void ParseSouthMovement()
        {
            var moveCommand = MoveCommand.Parse("S 1");

            Assert.AreEqual(Direction.South, moveCommand.Direction);
        }
    }

    public enum Direction
    {
        North,
        South,
        West,
        East
    }

    public class MoveCommand
    {
        public Direction Direction { get; set; }

        private MoveCommand(Direction direction)
        {
            Direction = direction;
        }


        internal static MoveCommand Parse(string moveCommand)
        {
            var direction = moveCommand[0] switch
            {
                'N' => Direction.North,
                'S' => Direction.South
            };

            return new MoveCommand(direction);
        }
    }

}
