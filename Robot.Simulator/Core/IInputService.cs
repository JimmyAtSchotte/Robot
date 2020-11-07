namespace Robot.Tests
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
