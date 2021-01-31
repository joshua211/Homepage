namespace homepage.Interfaces
{
    public interface IConsoleCommand
    {
        string Name { get; }
        void Execute(IWebConsole console, params string[] parameter);
        string ToHelp();
    }
}