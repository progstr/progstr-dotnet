using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Progstr.Log.Internal;

namespace Progstr.Tests
{
    public class TestClient : ProgstrClient
    {
        public TestClient() : base()
        {
        }
        
        public TestClient(NameValueCollection settings) : base(settings)
        {
        }

        private StringBuilder headerBuffer = new StringBuilder();

        public override void AddHeader(HttpWebRequest request, string name, string value)
        {
            headerBuffer.AppendLine(string.Format("{0}: {1}", name, value));
        }

        public string Headers
        {
            get { return headerBuffer.ToString(); }
        }
        
        public byte[] LastBody { get; private set; }
        
        public override void Execute(LogMessage message)
        {
            var request = CreateLogRequest(message);
            LastBody = request.Data;
        }
    }
}

