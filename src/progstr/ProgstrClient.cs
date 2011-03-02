using System;
namespace Progstr
{
    public class ProgstrClient
    {
        protected string apiToken;

        public ProgstrClient(string apiToken)
        {
            this.apiToken = apiToken;
        }

        public virtual void AddHeader(string name, string value)
        {
            
        }

        public void ConfigureRequest()
        {
            this.AddHeader("Accept", "application/json");
            this.AddHeader("Content-Type", "application/json");
            this.AddHeader("User-Agent", "progstr-dotnet " + MajorMinorVersion());
            this.AddHeader("X-Progstr-Token", this.apiToken);
        }

        public string MajorMinorVersion()
        {
            var assembly = typeof(ProgstrClient).Assembly;
            var version = assembly.GetName().Version;
            return string.Format("{0}.{1}", version.Major, version.Minor);
        }
    }
}

