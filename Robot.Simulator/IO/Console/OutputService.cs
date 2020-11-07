using Robot.Simulator.Core;

namespace Robot.Simulator.IO.Console
{
    public class OutputService : IOutputService
    {
        public void Output(string output)
        {
            System.Console.WriteLine(output);
        }
    }
}
