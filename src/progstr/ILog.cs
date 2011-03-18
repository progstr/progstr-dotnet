using System;
namespace Progstr.Log
{
    /// <summary>
    /// The log interface entry point that lets you format messages and send them to the server.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Log a message with the Info severity level.
        /// </summary>
        /// <param name="text">The log message.</param>
        void Info(string text);
        /// <summary>
        /// Log a message with the Info severity level and an associated exception.
        /// </summary>
        /// <param name="text">The log message.</param>
        /// <param name="error">An exception that may have occurred and needs to be logged as well.</param>
        void Info(string text, Exception error);
        /// <summary>
        /// Log a message with the Info severity level and format it with one or more objects.
        /// </summary>
        /// <param name="template">The format string template. It follows the same rules such as the format strings passed to <see cref="String.Format"/></param>
        /// <param name="args">The objects that need to be formatted.</param>
        void InfoFormat(string template, params object[] args);
        /// <summary>
        /// Log a message with the Warning severity level.
        /// </summary>
        /// <param name="text">The log message.</param>
        void Warning(string text);
        /// <summary>
        /// Log a message with the Warning severity level and an associated exception.
        /// </summary>
        /// <param name="text">The log message.</param>
        /// <param name="error">An exception that may have occurred and needs to be logged as well.</param>
        void Warning(string text, Exception error);
        /// <summary>
        /// Log a message with the Warning severity level and format it with one or more objects.
        /// </summary>
        /// <param name="template">The format string template. It follows the same rules such as the format strings passed to <see cref="String.Format"/></param>
        /// <param name="args">The objects that need to be formatted.</param>
        void WarningFormat(string template, params object[] args);
        /// <summary>
        /// Log a message with the Error severity level.
        /// </summary>
        /// <param name="text">The log message.</param>
        void Error(string text);
        /// <summary>
        /// Log a message with the Error severity level and an associated exception.
        /// </summary>
        /// <param name="text">The log message.</param>
        /// <param name="error">An exception that may have occurred and needs to be logged as well.</param>
        void Error(string text, Exception error);
        /// <summary>
        /// Log a message with the Error severity level and format it with one or more objects.
        /// </summary>
        /// <param name="template">The format string template. It follows the same rules such as the format strings passed to <see cref="String.Format"/></param>
        /// <param name="args">The objects that need to be formatted.</param>
        void ErrorFormat(string template, params object[] args);
        /// <summary>
        /// Log a message with the Fatal severity level.
        /// </summary>
        /// <param name="text">The log message.</param>
        void Fatal(string text);
        /// <summary>
        /// Log a message with the Fatal severity level and an associated exception.
        /// </summary>
        /// <param name="text">The log message.</param>
        /// <param name="error">An exception that may have occurred and needs to be logged as well.</param>
        void Fatal(string text, Exception error);
        /// <summary>
        /// Log a message with the Fatal severity level and format it with one or more objects.
        /// </summary>
        /// <param name="template">The format string template. It follows the same rules such as the format strings passed to <see cref="String.Format"/></param>
        /// <param name="args">The objects that need to be formatted.</param>
        void FatalFormat(string template, params object[] args);
    }
}

