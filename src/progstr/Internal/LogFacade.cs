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

        public void Info(string text)
        {
            this.LogWithLevel(LogLevel.Info, text);
        }

        public void Warning(string text)
        {
            this.LogWithLevel(LogLevel.Warning, text);
        }

        public void Error(string text)
        {
            this.LogWithLevel(LogLevel.Error, text);
        }

        public void Fatal(string text)
        {
            this.LogWithLevel(LogLevel.Fatal, text);
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

