using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Progstr.Log.Internal
{
    internal static class Shutdown
    {
        private static int pendingRequests = 0;

        static Shutdown()
        {
            AppDomain.CurrentDomain.DomainUnload += OnExit;
            AppDomain.CurrentDomain.ProcessExit += OnExit;
        }

        internal static void StartRequest()
        {
            Interlocked.Increment(ref pendingRequests);
        }

        internal static void EndRequest()
        {
            Interlocked.Decrement(ref pendingRequests);
        }

        private static void OnExit(object sender, EventArgs e)
        {
            //Wait 1.5 seconds and give any pending requests a chance to complete.
            for (var i = 0; i < 15; i++)
            {
                if (pendingRequests > 0)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
