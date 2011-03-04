using System;
using Xunit;

namespace Progstr.Tests
{
    public class BodySet
    {
        private TestClient client;
        private LogMessage message;
        private string jsonTemplate;
        
        public BodySet()
        {
            this.message = new LogMessage {
                Level = LogLevel.Fatal,
                Source = "test-source",
                Text = "Something wild",
                Time = Time.MillisecondNow
            };
            
            
            this.jsonTemplate = "{\"level\":5,\"source\":\"test-source\",\"text\":\"Something wild\",\"time\":[TIME]}";
            
            this.client = new TestClient("DEMO");
        }
        
        [Fact]
        public void BodySerialized()
        {
            client.Send(this.message);
            
            var expected = jsonTemplate.Replace("[TIME]", message.Time.ToString());
            client.LastBody.ShouldBe(expected);
        }
        
        [Fact]
        void BodyContainsOddCharacters()
        {
            message.Text = "\\'\"weird characters";   
            
            client.Send(this.message);
            
            var template = "{\"level\":5,\"source\":\"test-source\",\"text\":\"\\\\'\\\"weird characters\",\"time\":[TIME]}";
            var expected = template.Replace("[TIME]", message.Time.ToString());
            client.LastBody.ShouldBe(expected);
        }
        
        [Fact]
        void BodyContainsCyrillic()
        {
            message.Text = "проба на кирилица!";
            
            client.Send(this.message);
            
            var template = "{\"level\":5,\"source\":\"test-source\",\"text\":\"проба на кирилица!\",\"time\":[TIME]}";
            var expected = template.Replace("[TIME]", message.Time.ToString());
            client.LastBody.ShouldBe(expected);
        }
    }
}

