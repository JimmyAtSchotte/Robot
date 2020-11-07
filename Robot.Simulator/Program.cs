using System;
using Microsoft.Extensions.DependencyInjection;
using Robot.Simulator.Core;
using Robot.Simulator.IO.Console;
using Robot.Simulator.Robot;

namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IInputService, InputService>();
            serviceCollection.AddSingleton<IOutputService, OutputService>();
            serviceCollection.AddSingleton<IRobotApp, RobotApp>();
            serviceCollection.AddSingleton<ICleanedSpots, CleanedSpots>();
            
            var provider = serviceCollection.BuildServiceProvider();

            using var scope = provider.CreateScope();
            
            var robotApp = scope.ServiceProvider.GetService<IRobotApp>();
            robotApp.Run();
        }
    }
}
