using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.LogFiles
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string content);
    }
}
