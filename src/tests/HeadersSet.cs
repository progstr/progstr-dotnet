using System;
using System.Collections.Specialized;
using System.Text;
using Xunit;
using Progstr;

namespace Progstr.Tests
{
    public class HeadersSet
    {
        NameValueCollection settings = new NameValueCollection();
        
        public HeadersSet()
        {
            this.settings["progstr.log.apitoken"] = "7cf122aa-6df5-4fba-a5b3-f6f0a54e7b01";
        }

        [Fact]
        public void DefaultToCompression()
        {
            //throw new InvalidOperationException(this.settings["progstr.log.apitoken"]);
            var client = new TestClient(this.settings);
            client.ConfigureRequest(null);
            
            client.Headers.ShouldBe(@"Accept: application/json
Content-Type: application/json; charset=utf-8
Content-Encoding: gzip
User-Agent: progstr-dotnet 1.0
X-Progstr-Token: 7cf122aa-6df5-4fba-a5b3-f6f0a54e7b01
");
        }
        
        [Fact]
        public void DisableCompression()
        {
            this.settings["progstr.api.enablecompression"] = "false";
            var client = new TestClient(this.settings);
            client.ConfigureRequest(null);
            
            client.Headers.ShouldBe(@"Accept: application/json
Content-Type: application/json; charset=utf-8
User-Agent: progstr-dotnet 1.0
X-Progstr-Token: 7cf122aa-6df5-4fba-a5b3-f6f0a54e7b01
");
        }
    }
}
