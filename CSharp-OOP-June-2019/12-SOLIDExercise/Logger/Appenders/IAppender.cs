using Logger.Enumerations;
using Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string date, ReportLevel level, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
