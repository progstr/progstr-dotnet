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
            
            
            this.jsonTemplate = "{\"Level\":5,\"Source\":\"test-source\",\"Text\":\"Something wild\",\"Time\":[TIME]}";
            
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
            
            var template = "{\"Level\":5,\"Source\":\"test-source\",\"Text\":\"\\\\'\\\"weird characters\",\"Time\":[TIME]}";
            var expected = template.Replace("[TIME]", message.Time.ToString());
            client.LastBody.ShouldBe(expected);
        }
        
        [Fact]
        void BodyContainsCyrillic()
        {
            message.Text = "проба на кирилица!";
            
            client.Send(this.message);
            
            var template = "{\"Level\":5,\"Source\":\"test-source\",\"Text\":\"проба на кирилица!\",\"Time\":[TIME]}";
            var expected = template.Replace("[TIME]", message.Time.ToString());
            client.LastBody.ShouldBe(expected);
        }
    }
}

