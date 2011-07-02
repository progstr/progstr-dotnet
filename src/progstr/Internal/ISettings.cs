using System;

namespace Progstr.Log.Internal
{
    public interface ISettings
    {
        string BaseUrl { get; }
        string ApiToken { get; }
        bool? EnableCompression { get; }
    }
}
