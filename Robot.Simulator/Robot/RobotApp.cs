using System;
using Robot.Simulator.Core;

namespace Robot.Simulator.Robot
{

    public class RobotApp : IRobotApp
    {
        private readonly IInputService _inputService;
        private readonly IOutputService _outputService;

        public RobotApp(IInputService inputService, IOutputService outputService)
        {
            _inputService = inputService;
            _outputService = outputService;
        }

        public void Run()
        {
            var commands = Convert.ToInt32(_inputService.ReadNextInput());
            var startPosition = _inputService.ReadNextInput().Split(' ');

            var robot = new Robot(Convert.ToInt32(startPosition[0]), Convert.ToInt32(startPosition[1]));

            for (int i = 0; i < commands; i++)
                robot.Move(MoveCommand.Parse(_inputService.ReadNextInput()));

            _outputService.Output($"=> Cleaned: {robot.CalculateCleanedSpots()}");
        }
    }
}