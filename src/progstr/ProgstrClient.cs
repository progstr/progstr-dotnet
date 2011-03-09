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

namespace Progstr.Log
{
    public class ProgstrClient
    {
        protected string apiToken;
        protected NameValueCollection settings;

        public ProgstrClient(string apiToken) : this(apiToken, ConfigurationManager.AppSettings)
        {            
        }
        
        public ProgstrClient(string apiToken, NameValueCollection settings)
        {
            this.apiToken = apiToken;
            this.settings = settings;
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
        
        public virtual void Execute(LogRequest request)
        {
            request.Start();
        }
        
        public string ApiUrl
        {
            get
            {
                var baseUrl = this.settings["progstr.api.baseurl"] ?? "api.progstr.com";
                if (baseUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || 
                    baseUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                    return string.Format("{0}/log", baseUrl);
                else
                    return string.Format("http://{0}/log", baseUrl);
            }
        }
        
        public bool EnableCompression
        {
            get
            {
                var stringValue = this.settings["progstr.api.enablecompression"] ?? "true";
                return Convert.ToBoolean(stringValue);
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
            var webRequest = this.CreateWebRequest();
            this.ConfigureRequest(webRequest);
            
            var data = this.EncodeData(message);
            
            var request = new LogRequest(webRequest) { Data = data };
            this.Execute(request);
        }

        public string MajorMinorVersion()
        {
            var assembly = typeof(ProgstrClient).Assembly;
            var version = assembly.GetName().Version;
            return string.Format("{0}.{1}", version.Major, version.Minor);
        }
    }
}