using System;
using Common;

namespace Services.Logging
{
    public interface ILogService
    {
        /// <summary>
        /// logs the given request
        /// </summary>
        /// <returns></returns>
        void LogRequest(RequestLog requestLog);

        /// <summary>
        /// logs the given object as information
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        void LogInfo(LogType logType, object obj, string message);

        /// <summary>
        /// logs the given exc
        /// </summary>
        /// <returns></returns>
        void LogException(Exception exc);
    }
}
