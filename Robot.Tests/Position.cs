using System;

namespace Robot.Tests
{
    public class Position
    {
        public int Y { get; }
        public int X { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        private Position MoveX(int steps)
        {
            return new Position(this.X + steps, this.Y);
        }

        private Position MoveY(int steps)
        {
            return new Position(this.X, this.Y + steps);
        }

        public Position Move(IMoveCommand moveCommand)
        {
            return moveCommand.Direction switch
            {
                Direction.North => MoveY(moveCommand.Steps),
                Direction.South => MoveY(moveCommand.Steps * -1),
                Direction.West => MoveX(moveCommand.Steps * -1),
                Direction.East => MoveX(moveCommand.Steps)
            };
        }
    }
}
