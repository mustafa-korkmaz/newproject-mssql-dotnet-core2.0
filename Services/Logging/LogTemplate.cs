using System;
using Common;

namespace Services.Logging
{
    public class LogTemplate
    {
        private LogType _logType;
        private DateTime _logDate;

        public LogTemplate(LogType logType)
        {
            _logType = logType;
            _logDate = DateTime.UtcNow;
        }

        /// <summary>
        /// log message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// obj to log
        /// </summary>
        public object Object { get; set; }

        /// <summary>
        /// log creation date as string
        /// </summary>
        public string Date => _logDate.ToString("yyyyMMdd");

        /// <summary>
        /// log creation time as string
        /// </summary>
        public string Time => _logDate.ToString("HH:mm:ss:fff");

        /// <summary>
        /// log type as string
        /// </summary>
        public string LogType => _logType.ToString("G");
    }
}
