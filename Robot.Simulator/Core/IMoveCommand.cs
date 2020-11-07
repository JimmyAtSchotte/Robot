namespace Robot.Simulator.Core
{
    public interface IMoveCommand
    {
        Direction Direction { get; }
        int Steps { get; }
    }

}
