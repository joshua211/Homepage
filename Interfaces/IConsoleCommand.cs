using homepage.Console;

namespace homepage.Interfaces
{
    public interface IConsoleCommand
    {
        string Name { get; }
        string Description { get; }
        void Execute(IWebConsole console, params string[] parameter);
        DisplayContent ToHelp();
    }
}