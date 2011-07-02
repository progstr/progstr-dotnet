using System;
namespace Progstr.Log
{
    public static class LogSettings
    {
        /// <summary>
        /// Gets or sets your API access token. This parameter is mandatory - you won't be able to log otherwise. 
        /// </summary>
        public static string ApiToken
        {
            get; set;
        }
        
        /// <summary>
        /// The base URL of the progstr.log service endpoint. Setting to a value different than the default may break log requests.
        /// Don't set unless you know what you are doing or a support person has advised you to do so.
        /// </summary>
        public static string BaseUrl
        {
            get; set;
        }
        
        /// <summary>
        /// Gets or sets a value indicating whether log messages will be compressed before sent to the progstr.log servers. 
        /// The default is 'true'.
        /// </summary>
        public static bool? EnableCompression
        {
            get; set;
        }
    }
}

