using System;
using System.Collections.Generic;

namespace Robot.Tests
{
    public class Robot
    {
        private readonly Position _position;
        private readonly List<Position> _movementHistory;

        public Robot()
        {
            _position = new Position(0, 0);
        }

        internal Position Move(string movement)
        {
            var direction = movement[0];
            var steps = Convert.ToInt32(movement.Substring(2));

            return direction switch
            {
                'N' => _position.MoveY(steps),
                'S' => _position.MoveY(steps * -1),
                'W' => _position.MoveX(steps * -1),
                'E' => _position.MoveX(steps)
            };
        }    
    }
}
