using System;

namespace Progstr
{
    public class LogMessage
    {
        public LogMessage()
        {
        }

        public string Source
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
        public long Time
        {
            get;
            set;
        }
        public LogLevel Level
        {
            get;
            set;
        }
    }
}

