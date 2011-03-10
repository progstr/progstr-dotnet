using System;
using Xunit;
using System.Collections.Specialized;

namespace Progstr.Tests
{
    public class SettingsRead
    {
        NameValueCollection settings = new NameValueCollection();
        
        public SettingsRead()
        {
            this.settings["progstr.log.apitoken"] = "DEMO";
        }
        
        [Fact]
        public void ApiBaseUrl()
        {
            var client = new TestClient(this.settings);
            client.ApiUrl.ShouldBe("http://api.progstr.com/log");
        }
        
        [Fact]
        public void OverrideApiUrl()
        {
            this.settings["progstr.api.baseurl"] = "localhost:9091";
            var client = new TestClient(this.settings);
            client.ApiUrl.ShouldBe("http://localhost:9091/log");
        }
        
        [Fact]
        public void IgnoreLeadingProtocolForApiUrl()
        {
            this.settings["progstr.api.baseurl"] = "http://localhost:9091";
            var client = new TestClient(this.settings);
            client.ApiUrl.ShouldBe("http://localhost:9091/log");
        }
        
        [Fact]
        public void CompressionDefaultEnabled()
        {
            var client = new TestClient(this.settings);
            client.EnableCompression.ShouldBe(true);
        }
        
        [Fact]
        public void DisableCompression()
        {
            this.settings["progstr.api.enablecompression"] = "false";
            var client = new TestClient(this.settings);
            client.EnableCompression.ShouldBe(false);
        }
    }
}

