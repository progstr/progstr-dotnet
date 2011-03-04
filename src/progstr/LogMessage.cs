using System;
using System.Runtime.Serialization;

namespace Progstr
{
    [DataContract]
    public class LogMessage
    {
        [DataMember(Name = "source")]
        public string Source { get; set; }
        
        [DataMember(Name = "text")]
        public string Text { get; set; }
        
        [DataMember(Name = "time")]
        public long Time { get; set; }
        
        [DataMember(Name = "level")]
        public LogLevel Level { get; set; }
    }
}

