using System;
using Robot.Simulator.Core;

namespace Robot.Simulator.Robot
{

    public class RobotApp : IRobotApp
    {
        private readonly IInputService _inputService;
        private readonly IOutputService _outputService;
        private readonly ICleanedSpots _cleanedSpots;

        public RobotApp(IInputService inputService, IOutputService outputService, ICleanedSpots cleanedSpots)
        {
            _inputService = inputService;
            _outputService = outputService;
            _cleanedSpots = cleanedSpots;
        }
        
        public void Run()
        {
            var commands = Convert.ToInt32(_inputService.ReadNextInput());
            var startPosition = _inputService.ReadNextInput().Split(' ');
            
            var position = new Position(Convert.ToInt32(startPosition[0]), Convert.ToInt32(startPosition[1]));
            var robot = new Robot(_cleanedSpots, position);

            for (int i = 0; i < commands; i++)
                robot.Move(MoveCommand.Parse(_inputService.ReadNextInput()));

            _outputService.Output($"=> Cleaned: {robot.CalculateCleanedSpots()}");
        }
    }
}