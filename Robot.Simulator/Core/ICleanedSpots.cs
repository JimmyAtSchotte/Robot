using Robot.Simulator.Robot;

namespace Robot.Simulator.Core
{
    public interface ICleanedSpots
    {
        int CalculateCleanedSpots(Position[] positions);
    }
}