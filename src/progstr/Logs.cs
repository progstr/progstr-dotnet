using System;
using System.Collections.Generic;
using Progstr.Log.Internal;

namespace Progstr.Log
{
    /// <summary>
    /// This is the ILog object factory.
    /// </summary>
    public static class Logs
    {
        private static IDictionary<Type, ILog> logCache = new Dictionary<Type, ILog>();

        /// <summary>
        /// An extension method that returns an ILog implementation for a given type T.
        /// </summary>
        /// <typeparam name="T">The class that the message originates from.</typeparam>
        /// <param name="target">The instance of the source class.</param>
        /// <returns>An ILog instance.</returns>
        public static ILog Log<T>(this T target)
        {
            return Get<T>();
        }
        
        /// <summary>
        /// A factory method that returns an ILog implementation for a given type T.
        /// </summary>
        /// <typeparam name="T">The class that the message originates from.</typeparam>
        /// <returns>An ILog instance.</returns>
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

