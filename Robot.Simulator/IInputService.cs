namespace Robot.Tests
{
    public interface IInputService
    {
        string ReadNextInput();
    }

    public interface IOutputService
    {
        string Output(string output);
    }
}
