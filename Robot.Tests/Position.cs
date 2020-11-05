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

        public Position MoveX(int steps)
        {
            return new Position(this.X + steps, this.Y);
        }

        public Position MoveY(int steps)
        {
            return new Position(this.X, this.Y + steps);
        }
    }
}
