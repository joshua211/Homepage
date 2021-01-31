using System;
using System.Collections.Generic;
namespace homepage.Interfaces
{
    public interface IWebConsole
    {
        event Action NewDisplayContent;
        void Write(string content);
        void Error(string content, Exception e = null);
        void ComputeCommand(string command);
        List<string> DisplayContent { get; }
        string CurrentUser { get; }
        string CurrentDir { get; }

    }
}