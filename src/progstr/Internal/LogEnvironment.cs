using System;
using System.Net;
using System.Net.Sockets;

namespace Progstr.Log.Internal
{
    /// <summary>
    /// This class is meant for internal use only and should not be used directly from your code.
    /// </summary>
    public class LogEnvironment
    {
        private static string host;
        
        public static string Host
        {
            get
            {
                if (host == null)
                {
                    host = GetMachineName() ?? GetDnsHostName() ?? "Unknown";
                }
                return host;
            }
        }
        
        private static string GetMachineName()
        {
            try
            {
                return Environment.MachineName;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
        
        private static string GetDnsHostName()
        {
            try
            {
                return Dns.GetHostName();
            }
            catch (SocketException)
            {
                return null;
            }
        }
    }
}

