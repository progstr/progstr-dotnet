using System;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.IO.Compression;
using Xunit;
using Progstr.Log.Internal;

namespace Progstr.Tests
{
    public class BodySet
    {
        private TestClient client;
        private LogMessage message;
        private string jsonTemplate;
        private NameValueCollection settings;
        
        public BodySet()
        {
            this.message = new LogMessage {
                Level = LogLevel.Fatal,
                Source = "test-source",
                Host = "web-server1",
                Text = "Something wild",
                Time = Time.MillisecondNow
            };
            
            
            this.jsonTemplate = "{\"host\":\"web-server1\",\"level\":3,\"source\":\"test-source\",\"text\":\"Something wild\",\"time\":[TIME]}";
            
            this.settings = new NameValueCollection();
            this.settings["progstr.log.apitoken"] = "DEMO";
            this.client = new TestClient(this.settings);
        }
        
        private string Uncompress(byte[] data)
        {
            var buffer = new MemoryStream();
            buffer.Write(data, 0, data.Length);
            buffer.Seek(0, SeekOrigin.Begin);
            
            using (var reader = new StreamReader(new GZipStream(buffer, CompressionMode.Decompress), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        
        [Fact]
        public void BodySerializedAndCompressed()
        {
            client.Execute(this.message);
            
            var expected = jsonTemplate.Replace("[TIME]", message.Time.ToString());
            Uncompress(client.LastBody).ShouldBe(expected);
        }
        
        [Fact]
        public void BodyContainsOddCharacters()
        {
            message.Text = "\\'\"weird characters";   
            
            client.Execute(this.message);
            
            var template = "{\"host\":\"web-server1\",\"level\":3,\"source\":\"test-source\",\"text\":\"\\\\'\\\"weird characters\",\"time\":[TIME]}";
            var expected = template.Replace("[TIME]", message.Time.ToString());
            Uncompress(client.LastBody).ShouldBe(expected);
        }
        
        [Fact]
        public void BodyContainsCyrillic()
        {
            message.Text = "проба на кирилица!";
            
            client.Execute(this.message);
            
            var template = "{\"host\":\"web-server1\",\"level\":3,\"source\":\"test-source\",\"text\":\"проба на кирилица!\",\"time\":[TIME]}";
            var expected = template.Replace("[TIME]", message.Time.ToString());
            Uncompress(client.LastBody).ShouldBe(expected);
        }
        
        [Fact]
        public void UncompressedBody()
        {
            this.settings["progstr.api.enablecompression"] = "false";
            client.Execute(this.message);
            
            var expected = jsonTemplate.Replace("[TIME]", message.Time.ToString());
            client.LastBody.ShouldBe(Encoding.UTF8.GetBytes(expected));
        }
    }
}