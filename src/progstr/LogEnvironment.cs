using System;
using System.Net;
using System.Net.Sockets;

namespace Progstr.Log
{
    public class LogEnvironment
    {
        public static string Host
        {
            get
            {
                return GetMachineName() ?? GetDnsHostName() ?? "Unknown";   
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

