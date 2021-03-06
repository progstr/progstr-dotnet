using System;
namespace Progstr.Log.Internal
{
    /// <summary>
    /// This class is meant for internal use only and should not be used directly from your code.
    /// </summary>
    public class Time
    {
        public Time()
        {
        }
        
        private static DateTime epochStart = new DateTime(1970, 1, 1);
        
        /// <summary>
        /// Get the current time represented as the number of milliseconds ellapsed since
        /// January 1, 1970 0:00.
        /// 
        /// Note that times are in UTC!
        /// </summary>
        public static long MillisecondNow
        {
            get
            {
                var ellapsed = (DateTime.UtcNow - epochStart);
                return (long) ellapsed.TotalMilliseconds;
            }
        }
    }
}

