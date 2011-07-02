using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Progstr.Log.Internal
{
    public class ConfigFileSettings : ISettings
    {
        private NameValueCollection config;
        
        public ConfigFileSettings() : this(ConfigurationManager.AppSettings)
        {
        }
        
        public ConfigFileSettings(NameValueCollection config)
        {
            this.config = config;
        }
        
        public string BaseUrl 
        {
            get
            {
                return this.config["progstr.api.baseurl"];
            }
        }
        public string ApiToken
        {
            get
            {
                return this.config["progstr.log.apitoken"];
            }
        }
        public bool? EnableCompression
        {
            get
            {
                var stringValue = this.config["progstr.api.enablecompression"];
                if (!String.IsNullOrEmpty(stringValue))
                    return Convert.ToBoolean(this.config["progstr.api.enablecompression"]);
                else
                    return null;
            }
        }
    }
}
