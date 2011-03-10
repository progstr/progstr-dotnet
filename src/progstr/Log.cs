using System;
using System.Collections.Generic;
using Progstr.Log.Internal;

namespace Progstr.Log
{
    public static class Log
    {
        private static IDictionary<Type, ILog> logCache = new Dictionary<Type, ILog>();

        public static ILog Log<T>(this T target)
        {
            return Progstr.Log.Log.For<T>();
        }
        
        public static ILog For<T>()
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

