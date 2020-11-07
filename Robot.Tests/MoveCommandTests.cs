﻿using NUnit.Framework;
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

        [Test]
        public void ParseWestMovement()
        {
            var moveCommand = MoveCommand.Parse("W 1");

            Assert.AreEqual(Direction.West, moveCommand.Direction);
        }

        [Test]
        public void ParseEastMovement()
        {
            var moveCommand = MoveCommand.Parse("E 1");

            Assert.AreEqual(Direction.East, moveCommand.Direction);
        }



        [TestCase("N", 1)]
        [TestCase("S", 2)]
        [TestCase("W", -3)]
        [TestCase("E", -4)]
        public void ParseStepsInANyDirectionMovement(string direction, int steps)
        {
            var moveCommand = MoveCommand.Parse($"{direction} {steps}");

            Assert.AreEqual(steps, moveCommand.Steps);
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
        public Direction Direction { get; }
        public int Steps { get; }

        private MoveCommand(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }


        internal static MoveCommand Parse(string moveCommand)
        {
            var direction = moveCommand[0] switch
            {
                'N' => Direction.North,
                'S' => Direction.South,
                'W' => Direction.West,
                'E' => Direction.East
            };
            var steps = Convert.ToInt32(moveCommand.Substring(2));


            return new MoveCommand(direction, steps);
        }
    }

}