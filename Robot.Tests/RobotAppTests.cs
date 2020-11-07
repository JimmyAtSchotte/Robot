using ArrangeDependencies.Autofac;
using ArrangeDependencies.Autofac.Extensions;
using Moq;
using NUnit.Framework;

namespace Robot.Tests
{
    [TestFixture]
    public class RobotAppTests
    {      
        [Test]
        public void ExecuteRobotCommands()
        {
            Mock<IIOAdapter> io = null;

            var arrange = Arrange.Dependencies<IRobotApp, RobotApp>(dependencies =>
            {
                dependencies.UseMock(mock => mock.SetupSequence(x => x.ReadLine())
                                                            .Returns("2")
                                                            .Returns("10 22")
                                                            .Returns("E 2")
                                                            .Returns("N 1"), out io);
            });
            var robotApp = arrange.Resolve<IRobotApp>();
            robotApp.Run();

            io.Verify(x => x.WriteLine("=> Cleaned: 4"), Times.Once);
        }
    }

    public interface IIOAdapter
    {
        string ReadLine();
        string WriteLine(string output);
    }
}
