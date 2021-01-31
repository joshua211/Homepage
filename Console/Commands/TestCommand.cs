using homepage.Enums;
using homepage.Interfaces;

namespace homepage.Console.Commands
{
    public class TestCommand : IConsoleCommand
    {
        public string Name => "test";

        public string Description => "Just testing some stuff";

        public void Execute(IWebConsole console, params string[] parameter)
        {
            console.Write("This is a test!");
            console.Write("I am testing more stuff!");
            console.Write(new DisplayContent("And some more!", true, Colors.Info, true));
            console.Error("Wrong");
        }

        public DisplayContent ToHelp()
        {
            return new DisplayContent("Usage: test [first] [second]");
        }
    }
}