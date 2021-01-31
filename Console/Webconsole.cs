using System;
using System.Collections.Generic;
using System.Linq;
using homepage.Interfaces;

namespace homepage.Console
{
    public class Webconsole : IWebConsole
    {
        public event Action NewDisplayContent;
        public List<string> DisplayContent { get; private set; }
        public string CurrentUser { get; private set; }
        public string CurrentDir { get; private set; }

        private Dictionary<string, IConsoleCommand> commands;

        public Webconsole(IEnumerable<IConsoleCommand> cmds)
        {
            DisplayContent = new();
            commands = cmds.ToDictionary(c => c.Name);
            CurrentUser = "User";
            CurrentDir = "~";
        }

        public void Write(string content)
        {
            System.Console.WriteLine("Write: " + content);
            DisplayContent.Add(content + "<br/>");
            NewDisplayContent?.Invoke();
        }

        public void Error(string content, Exception e = null)
        {
            DisplayContent.Add(ToError(content));
            NewDisplayContent?.Invoke();
        }

        public void ComputeCommand(string commandName)
        {
            Write(GetPrefix() + ' ' + commandName);
            if (String.IsNullOrWhiteSpace(commandName))
                return;

            var parts = commandName.Split(' ');

            if (commands.TryGetValue(parts[0], out var command))
            {
                if (parts.Length > 1 && parts[1].ToLower() == "help")
                {
                    System.Console.WriteLine("Help");
                    Write(command.ToHelp());
                    return;
                }
                else
                    command.Execute(this, parts.Skip(1).ToArray());

            }
            else
            {
                Error($"No such command found. Try {ToCommandNameDisplay("help")} to get a list of all commands");
            }
        }

        private string GetPrefix() =>
            $"<span class=\"text-azure\">@{CurrentUser}</span><span class=\"text-console2\">:{CurrentDir}$</span>";


        private string ToError(string message) =>
            $"<span class=\"text-red-700\">{message}</span><br/>";


        private string ToCommandNameDisplay(string name) =>
            $"<span class=\"text-blue-300\">{name}</span>";
    }
}