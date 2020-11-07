using Robot.Simulator.Core;

namespace Robot.Simulator.IO.Console
{
    public class InputService : IInputService
    {
        public string ReadNextInput()
        {
            return System.Console.ReadLine();
        }
    }
}
