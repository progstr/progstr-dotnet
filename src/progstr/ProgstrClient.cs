using System;
using System.IO;
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

        public ProgstrClient(string apiToken)
        {
            this.apiToken = apiToken;
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
            this.AddHeader("User-Agent", "progstr-dotnet " + MajorMinorVersion());
            this.AddHeader("X-Progstr-Token", this.apiToken);
        }

        string body = "";
        public virtual void AddBody(string json)
        {
            body = json;
        }

        public virtual void ConfigureBody(LogMessage message)
        {
            var buffer = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(LogMessage));
            serializer.WriteObject(buffer, message);
            
            buffer.Seek(0, SeekOrigin.Begin);
            var data = new byte[buffer.Length];
            buffer.Read(data, 0, data.Length);
            
            var json = Encoding.UTF8.GetString(data);
            this.AddBody(json);
        }

        public virtual void Execute()
        {
            this.request.ContentLength = Encoding.UTF8.GetByteCount(this.body);
            
            using (var requestStream = this.request.GetRequestStream())
            {
                requestStream.Write(Encoding.UTF8.GetBytes(this.body), 0, Encoding.UTF8.GetByteCount(this.body));
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
        
        private void CreateWebRequest()
        {
            var baseUrl = ConfigurationManager.AppSettings["progstr.api.baseurl"] ?? "api.progstr.com";
            var fullUrl = string.Format("http://{0}/log", baseUrl);
            
            this.request = (HttpWebRequest) WebRequest.Create(fullUrl);
            ServicePointManager.Expect100Continue = false;
            
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