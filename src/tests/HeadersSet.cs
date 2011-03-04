using System;
using System.Text;
using Xunit;
using Progstr;

namespace Progstr.Tests
{
    public class HeadersSet
    {
        public HeadersSet()
        {
        }

        [Fact]
        public void ConfigureHeaders()
        {
            var client = new TestClient("7cf122aa-6df5-4fba-a5b3-f6f0a54e7b01");
            client.ConfigureRequest();
            
            client.Headers.ShouldBe(@"Accept: application/json
Content-Type: application/json; charset=utf-8
User-Agent: progstr-dotnet 1.0
X-Progstr-Token: 7cf122aa-6df5-4fba-a5b3-f6f0a54e7b01
");
        }
    }
}
