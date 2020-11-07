using System;

namespace Robot.Tests
{
    public interface IRobotApp
    {
        void Run();
    }

    public class RobotApp : IRobotApp
    {
        private readonly IIOAdapter _io;

        public RobotApp(IIOAdapter io)
        {
            _io = io;
        }

        public void Run()
        {
            var commands = Convert.ToInt32(_io.ReadLine());
            var startPosition = _io.ReadLine().Split(' ');

            var robot = new Robot(Convert.ToInt32(startPosition[0]), Convert.ToInt32(startPosition[1]));

            for (int i = 0; i < commands; i++)
                robot.Move(MoveCommand.Parse(_io.ReadLine()));

            _io.WriteLine($"=> Cleaned: {robot.CalculateCleanedSpots()}");
        }
    }
}