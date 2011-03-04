using System;
using System.Text;

namespace Progstr.Tests
{
    public class TestClient : ProgstrClient
    {
        public TestClient(string apiToken) : base(apiToken)
        {
        }

        private StringBuilder headerBuffer = new StringBuilder();

        public override void AddHeader(string name, string value)
        {
            headerBuffer.AppendLine(string.Format("{0}: {1}", name, value));
        }

        public string Headers
        {
            get { return headerBuffer.ToString(); }
        }
        
        public string LastBody { get; private set; }
        
        public override void AddBody(string json)
        {
            LastBody = json;
        }
    }
}

