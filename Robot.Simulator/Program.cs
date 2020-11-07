using System;
using Robot.Simulator.IO.Console;
using Robot.Simulator.Robot;

namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputService = new InputService();
            var outputService = new OutputService();

            var robotApp = new RobotApp(inputService, outputService);

            robotApp.Run();
        }
    }
}
