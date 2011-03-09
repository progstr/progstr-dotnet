using System;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Progstr.Log
{
    public class LogRequest
    {
        public LogRequest(HttpWebRequest webRequest)
        {
            this.Request = webRequest;    
        }
        
        public HttpWebRequest Request { get; private set; }
        public byte[] Data { get; set; }
        
        public void Start()
        {
            this.Request.ContentLength = this.Data.Length;
            
            this.Request.BeginGetRequestStream(OnGetRequestStream, null);
        }
        
        private void OnGetRequestStream(IAsyncResult result)
        {
            var requestStream = this.Request.EndGetRequestStream(result);
            
            requestStream.BeginWrite(this.Data, 0, this.Data.Length, OnDataWritten, requestStream);
        }
        
        private void OnDataWritten(IAsyncResult result)
        {
            var requestStream = (Stream) result.AsyncState;
            requestStream.EndWrite(result);
            requestStream.Flush();
            requestStream.Close();
            
            this.Request.BeginGetResponse(OnGetResponse, null);
        }
        
        private void OnGetResponse(IAsyncResult result)
        {
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) this.Request.EndGetResponse(result);
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
                Trace.TraceError("Log HTTP request failed with status: " + statusCode);
                Debug.WriteLine("Response body:\r\n" + responseBody);
                Trace.TraceError("Response body:\r\n" + responseBody);
            }
        }
    }
}

