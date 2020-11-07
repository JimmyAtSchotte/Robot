using ArrangeDependencies.Autofac;
using ArrangeDependencies.Autofac.Extensions;
using Moq;
using NUnit.Framework;
using Robot.Simulator.Core;
using Robot.Simulator.Robot;

namespace Robot.Tests
{
    [TestFixture]
    public class RobotAppTests
    {      
        [Test]
        public void ExecuteRobotCommands()
        {
            Mock<IOutputService> outputService = null;

            var arrange = Arrange.Dependencies<IRobotApp, RobotApp>(dependencies =>
            {
                dependencies.UseMock<IInputService>(mock => mock.SetupSequence(x => x.ReadNextInput())
                                                            .Returns("2")
                                                            .Returns("10 22")
                                                            .Returns("E 2")
                                                            .Returns("N 1"));
                dependencies.UseMock(out outputService);
            });

            var robotApp = arrange.Resolve<IRobotApp>();
            robotApp.Run();

            outputService.Verify(x => x.Output("=> Cleaned: 4"), Times.Once);
        }
    }
}
