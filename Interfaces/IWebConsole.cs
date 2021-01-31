using System;
using System.Collections.Generic;
using homepage.Console;

namespace homepage.Interfaces
{
    public interface IWebConsole
    {
        event Action NewDisplayContent;
        void Write(IEnumerable<DisplayContent> content);
        void Write(DisplayContent content);
        void Write(string content);
        void Error(string content, Exception e = null);
        void ComputeCommand(string command);
        List<DisplayContent> DisplayContent { get; }
        IEnumerable<IConsoleCommand> AvailableCommands { get; }
        string CurrentUser { get; }
        string CurrentDir { get; }

    }
}