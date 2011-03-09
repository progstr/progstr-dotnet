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

        public virtual void AddHeader(string name, string value)
        {
            if (name == "Accept")
                this.request.Accept = value;
            else if (name == "Content-Type")
                this.request.ContentType = value;
            else if (name == "User-Agent")
                this.request.UserAgent = value;
            else
                this.request.Headers[name] = value;
        }

        public void ConfigureRequest()
        {
            this.AddHeader("Accept", "application/json");
            this.AddHeader("Content-Type", "application/json; charset=utf-8");
            if (this.EnableCompression)
                this.AddHeader("Content-Encoding", "gzip");
            this.AddHeader("Accept-Encoding", "gzip");
            this.AddHeader("User-Agent", "progstr-dotnet " + MajorMinorVersion());
            this.AddHeader("X-Progstr-Token", this.apiToken);
        }

        byte[] body = new byte[0];
        public virtual void AddBody(byte[] body)
        {
            this.body = body;
        }

        public virtual void ConfigureBody(LogMessage message)
        {
            var buffer = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(LogMessage));
            serializer.WriteObject(buffer, message);
            
            var data = buffer.ToArray();
            if (this.EnableCompression)
                data = this.Compress(data);
            
            this.AddBody(data);
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
        
        public virtual void Execute()
        {
            this.request.ContentLength = this.body.Length;
            
            using (var requestStream = this.request.GetRequestStream())
            {
                requestStream.Write(this.body, 0, this.body.Length);
            }
            
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) this.request.GetResponse();
            }
            catch (WebException requestException)
            {
                response = (HttpWebResponse) requestException.Response;
            }
            
            var statusCode = response.StatusCode;
            
            var reader = new StreamReader(response.GetResponseStream());
            var responseBody = reader.ReadToEnd();
            
            if (statusCode != HttpStatusCode.OK)
            {
                Debug.WriteLine("Log HTTP request failed with status: " + statusCode);
                Debug.WriteLine("Response body:\r\n" + responseBody);
            }
        }

        private HttpWebRequest request;
        
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
        
        private void CreateWebRequest()
        {
            this.request = (HttpWebRequest) WebRequest.Create(ApiUrl);
            
            this.request.Method = "POST";
        }

        public virtual void Send(LogMessage message)
        {
            this.CreateWebRequest();
            
            this.ConfigureRequest();
            this.ConfigureBody(message);
            this.Execute();
        }

        public string MajorMinorVersion()
        {
            var assembly = typeof(ProgstrClient).Assembly;
            var version = assembly.GetName().Version;
            return string.Format("{0}.{1}", version.Major, version.Minor);
        }
    }
}