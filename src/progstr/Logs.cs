using System;
using System.Collections.Generic;
using Progstr.Log.Internal;

namespace Progstr.Log
{
    public static class Logs
    {
        private static IDictionary<Type, ILog> logCache = new Dictionary<Type, ILog>();

        public static ILog Log<T>(this T target)
        {
            return Get<T>();
        }
        
        public static ILog Get<T>()
        {
            var type = typeof(T);
            
            if (!logCache.ContainsKey(type))
            {
                logCache[type] = CreateLog(type);
            }

            return logCache[type];
        }

        private static ILog CreateLog(Type type)
        {
            return new LogFacade(type.FullName);
        }
    }
}

