using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace Robot.Tests
{
    [TestFixture]
    public class MoveCommandTests
    {
        [Test]
        public void ShouldParseNorthMovement()
        {
            var moveCommand = MoveCommand.Parse("N 1");

            Assert.AreEqual(Direction.North, moveCommand.Direction);
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
                'N' => Direction.North
            };

            return new MoveCommand(direction);
        }
    }

}
