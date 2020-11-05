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

        internal Position Move(string movement)
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
                case 'W':
                    _position.X -= steps;
                    break;
                case 'E':
                    _position.X += steps;
                    break;
                default:
                    break;
            }

            return _position;

        }

        internal Position GetPosition()
        {
            return _position;
        }
    }
}
