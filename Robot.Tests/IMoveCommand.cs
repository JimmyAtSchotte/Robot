namespace Robot.Tests
{
    public interface IMoveCommand
    {
        Direction Direction { get; }
        int Steps { get; }
    }

}
