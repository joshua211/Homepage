using homepage.Interfaces;

namespace homepage.Console.Commands
{
    public class TestCommand : IConsoleCommand
    {
        public string Name => "test";

        public void Execute(IWebConsole console, params string[] parameter)
        {
            console.Write("This is a test!");
            console.Write("I am testing more stuff! \nAnd some mire");
            console.Error("Wrong");
        }

        public string ToHelp()
        {
            return "Usage: test [first] [second]";
        }
    }
}