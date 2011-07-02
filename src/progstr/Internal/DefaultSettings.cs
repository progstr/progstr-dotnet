using System;
namespace Progstr.Log.Internal
{
    public class DefaultSettings : ISettings
    {
        private ISettings configSettings;
        
        public DefaultSettings(ISettings configSettings)
        {
            this.configSettings = configSettings;
        }
        
        public string BaseUrl 
        {
            get
            {
                return LogSettings.BaseUrl ?? this.configSettings.BaseUrl ?? "api.progstr.com";
            }
        }
        public string ApiToken
        {
            get
            {
                return LogSettings.ApiToken ?? this.configSettings.ApiToken;
            }
        }
        public bool? EnableCompression
        {
            get
            {
                return LogSettings.EnableCompression ?? this.configSettings.EnableCompression  ?? true;
            }
        }
    }
}

