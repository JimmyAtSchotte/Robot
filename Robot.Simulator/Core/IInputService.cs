namespace Robot.Simulator.Core
{
    public interface IInputService
    {
        string ReadNextInput();
    }

    public interface IOutputService
    {
        void Output(string output);
    }
}
