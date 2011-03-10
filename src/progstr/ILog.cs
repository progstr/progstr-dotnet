using System;
namespace Progstr.Log
{
    public interface ILog
    {
        void Info(string text);
        void Warning(string text);
        void Error(string text);
        void Fatal(string text);
    }
}

