using System;
namespace Progstr.Log
{
    public interface ILog
    {
        void Info(string text);
        void Info(string text, Exception error);
        void InfoFormat(string template, params object[] args);
        void Warning(string text);
        void Warning(string text, Exception error);
        void WarningFormat(string template, params object[] args);
        void Error(string text);
        void Error(string text, Exception error);
        void ErrorFormat(string template, params object[] args);
        void Fatal(string text);
        void Fatal(string text, Exception error);
        void FatalFormat(string template, params object[] args);
    }
}

