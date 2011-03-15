using System;
using Progstr.Log;

namespace Progstr.Log.Internal
{
    public class LogFacade : ILog
    {
        private string source;

        public LogFacade(string source)
        {
            this.source = source;
        }
        
        private string FormatException(string text, Exception error)
        {
            return string.Format("{0}\r\nException:\r\n{1}", text, error);
        }
        
        private string FormatObjects(string template, params object[] args)
        {
            return string.Format(template, args);
        }

        public void Info(string text)
        {
            this.LogWithLevel(LogLevel.Info, text);
        }
        
        public void Info(string text, Exception error)
        {
            this.Info(FormatException(text, error));
        }
        
        public void InfoFormat(string template, params object[] args)
        {
            this.Info(FormatObjects(template, args));
        }

        public void Warning(string text)
        {
            this.LogWithLevel(LogLevel.Warning, text);
        }
        
        public void Warning(string text, Exception error)
        {
            this.Warning(FormatException(text, error));
        }
        
        public void WarningFormat(string template, params object[] args)
        {
            this.Warning(FormatObjects(template, args));
        }

        public void Error(string text)
        {
            this.LogWithLevel(LogLevel.Error, text);
        }
        
        public void Error(string text, Exception error)
        {
            this.Error(FormatException(text, error));
        }
        
        public void ErrorFormat(string template, params object[] args)
        {
            this.Error(FormatObjects(template, args));
        }

        public void Fatal(string text)
        {
            this.LogWithLevel(LogLevel.Fatal, text);
        }
        
        public void Fatal(string text, Exception error)
        {
            this.Fatal(FormatException(text, error));
        }
        
        public void FatalFormat(string template, params object[] args)
        {
            this.Fatal(FormatObjects(template, args));
        }

        private void LogWithLevel(LogLevel level, string text)
        {
            var message = new LogMessage {
                Source = this.source,
                Text = text,
                Level = level,
                Host = LogEnvironment.Host,
                Time = Time.MillisecondNow
            };

            this.Client.Send(message);
        }
        
        private ProgstrClient client;
        private ProgstrClient Client
        {
            get
            {
                if (client == null)
                    client = new ProgstrClient();
                return client;
            }
        }
    }
}

