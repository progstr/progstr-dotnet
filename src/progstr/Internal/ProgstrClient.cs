using System;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Diagnostics;
using System.Configuration;

namespace Progstr.Log.Internal
{
    /// <summary>
    /// This class is meant for internal use only and should not be used directly from your code.
    /// </summary>
    public class ProgstrClient
    {
        protected string apiToken;
        private ISettings settings;

        public ProgstrClient() : this(new DefaultSettings(new ConfigFileSettings()))
        {            
        }
        
        public ProgstrClient(ISettings settings)
        {
            this.settings = settings;

            this.apiToken = this.settings.ApiToken;
            if (string.IsNullOrEmpty(this.apiToken))
                throw new InvalidOperationException("Bad or missing API token. Make sure the 'progstr.log.apitoken' setting is set.");
        }

        public virtual void AddHeader(HttpWebRequest request, string name, string value)
        {
            if (name == "Accept")
                request.Accept = value;
            else if (name == "Content-Type")
                request.ContentType = value;
            else if (name == "User-Agent")
                request.UserAgent = value;
            else
                request.Headers[name] = value;
        }

        public void ConfigureRequest(HttpWebRequest request)
        {
            this.AddHeader(request, "Accept", "application/json");
            this.AddHeader(request, "Content-Type", "application/json; charset=utf-8");
            if (this.EnableCompression)
                this.AddHeader(request, "Content-Encoding", "gzip");
            this.AddHeader(request, "User-Agent", "progstr-dotnet " + MajorMinorVersion());
            this.AddHeader(request, "X-Progstr-Token", this.apiToken);
        }

        private byte[] EncodeData(LogMessage message)
        {
            var buffer = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(LogMessage));
            serializer.WriteObject(buffer, message);
            
            var data = buffer.ToArray();
            if (this.EnableCompression)
                data = this.Compress(data);
            
            return data;
        }

        private byte[] Compress(byte[] input)
        {
            var buffer = new MemoryStream();
            using (var compressor = new GZipStream(buffer, CompressionMode.Compress))
            {
                compressor.Write(input, 0, input.Length);
            }
            return buffer.ToArray();
        }
        
        protected LogRequest CreateLogRequest(LogMessage message)
        {
            var webRequest = this.CreateWebRequest();
            this.ConfigureRequest(webRequest);
            
            var data = this.EncodeData(message);
            
            return new LogRequest(webRequest) { Data = data };
            
        }
        
        public virtual void Execute(LogMessage message)
        {
            var request = this.CreateLogRequest(message);
            request.Start();
        }
        
        public string ApiUrl
        {
            get
            {
                var baseUrl = this.settings.BaseUrl;
                if (baseUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || 
                    baseUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    return string.Format("{0}/v1/log", baseUrl);
                else
                    return string.Format("http://{0}/v1/log", baseUrl);
            }
        }
        
        public bool EnableCompression
        {
            get
            {
                return (bool) this.settings.EnableCompression;
            }
        }
        
        private HttpWebRequest CreateWebRequest()
        {
            var request = (HttpWebRequest) WebRequest.Create(ApiUrl);
            request.Method = "POST";
            return request;
        }

        public virtual void Send(LogMessage message)
        {
            Action asyncAction = () => {
                this.Execute(message);
            };
            asyncAction.BeginInvoke((result) => {}, null);
        }

        public string MajorMinorVersion()
        {
            var assembly = typeof(ProgstrClient).Assembly;
            var version = assembly.GetName().Version;
            return string.Format("{0}.{1}", version.Major, version.Minor);
        }
    }
}