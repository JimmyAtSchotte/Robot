using System;
using Robot.Simulator.Core;

namespace Robot.Simulator.Robot
{

    public class MoveCommand : IMoveCommand
    {
        public Direction Direction { get; }
        public int Steps { get; }

        private MoveCommand(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
        
        public static MoveCommand Parse(string moveCommand)
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
