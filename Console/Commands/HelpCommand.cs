using System.Collections.Generic;
using System.Linq;
using homepage.Enums;
using homepage.Interfaces;

namespace homepage.Console.Commands
{
    public class HelpCommand : IConsoleCommand
    {
        public string Name => "help";

        public string Description => "Help";

        public void Execute(IWebConsole console, params string[] parameter)
        {
            var commands = console.AvailableCommands;
            console.Write(new DisplayContent("Available commands: ", true));
            foreach (var c in commands)
            {
                if (c.Name == Name)
                    return;
                console.Write(new DisplayContent(c.Name + ": ", false, Colors.Info));
                console.Write(new DisplayContent(c.Description, true));
            }
            console.Write("");
        }

        public DisplayContent ToHelp()
        {
            return new DisplayContent("");
        }
    }
}