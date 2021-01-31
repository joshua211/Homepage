using System;
using System.Collections.Generic;
using System.Linq;
using homepage.Enums;
using homepage.Interfaces;

namespace homepage.Console
{
    public class Webconsole : IWebConsole
    {
        public event Action NewDisplayContent;
        public List<DisplayContent> DisplayContent { get; private set; }
        public string CurrentUser { get; private set; }
        public string CurrentDir { get; private set; }

        public IEnumerable<IConsoleCommand> AvailableCommands { get; }

        private Dictionary<string, IConsoleCommand> commands;

        public Webconsole(IEnumerable<IConsoleCommand> cmds)
        {
            DisplayContent = new();
            AvailableCommands = cmds;
            commands = cmds.ToDictionary(c => c.Name);
            CurrentUser = "User";
            CurrentDir = "~";
        }

        public void Write(DisplayContent content)
        {
            DisplayContent.Add(content);
            NewDisplayContent?.Invoke();
        }

        public void Write(IEnumerable<DisplayContent> content)
        {
            DisplayContent.AddRange(content);
            NewDisplayContent?.Invoke();
        }

        public void Write(string content)
        {
            Write(new Console.DisplayContent(content, true));
        }

        public void Error(string content, Exception e = null)
        {
            Write(new DisplayContent(content, true, Colors.Error));
            if (e is not null)
                Write(new DisplayContent(e.Message, true, Colors.Error));
            NewDisplayContent?.Invoke();
        }

        public void ComputeCommand(string commandName)
        {
            Write(GetPrefix());
            Write(new DisplayContent(" " + commandName, true, Colors.Command));

            if (String.IsNullOrWhiteSpace(commandName))
                return;

            var parts = commandName.Split(' ');

            if (commands.TryGetValue(parts[0], out var command))
            {
                if (parts.Length > 1 && parts[1].ToLower() == "help")
                {
                    Write(command.ToHelp());
                    return;
                }
                else
                    command.Execute(this, parts.Skip(1).ToArray());
            }
            else
            {
                Write(new DisplayContent("No such command found. Try ", false, Colors.Error));
                Write(new DisplayContent("help ", false, Colors.Info));
                Write(new DisplayContent("to get a list of all commands", true, Colors.Error));
            }
        }

        private IEnumerable<DisplayContent> GetPrefix()
        {
            yield return new DisplayContent("@" + CurrentUser, color: Colors.Username);
            yield return new DisplayContent(":" + CurrentDir + "$", color: Colors.Console);
        }
    }
}