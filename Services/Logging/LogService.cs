using System.IO;
using System.Text;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Services.Logging
{
    public class LogService : ILogService
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly string _basePath;

        public LogService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
            _basePath = Directory.GetCurrentDirectory();
        }

        public void LogInfo(LogType logType, object obj, string message)
        {
            var infoLoggingPath = _basePath + _appSettings.Value.InfoLoggingPath;

            var logTemplate = new LogTemplate(logType)
            {
                Message = message,
                Object = obj,
            };

            WriteLog(infoLoggingPath, logTemplate);

        }

        public void LogException(RequestLog requestLog)
        {
            var errorLoggingPath = _basePath + _appSettings.Value.ErrorLoggingPath;
        }

        public void LogRequest(RequestLog requestLog)
        {
            var requestLoggingPath = _basePath + _appSettings.Value.ReqAndRespLoggingPath;

            var logTemplate = new LogTemplate(LogType.ReqAndResp)
            {
                Message = requestLog.HttpResponseCode.ToString(),
                Object = requestLog.RequestContent
            };

            WriteLog(requestLoggingPath, logTemplate);
        }

        private void WriteLog(string filePath, LogTemplate template)
        {
            var objStr = template.Object != null ? JsonConvert.SerializeObject(template.Object, Formatting.Indented) : "null";
            var msg = template.Message ?? "null";


            var strBuilder = new StringBuilder();

            //add log creation date
            strBuilder.Append("Date: " + template.Date);

            //add space
            strBuilder.Append(" ");

            //add log creation date
            strBuilder.Append("Time: " + template.Time);

            //add space
            strBuilder.Append(" ");

            //add log creation date
            strBuilder.Append("Type: " + template.LogType);

            //add space
            strBuilder.Append(" ");

            //add message
            strBuilder.Append("Msg: " + msg);

            //add space
            strBuilder.Append(" ");

            //add objStr as json
            strBuilder.Append("Obj: " + objStr);


            // This text is always added, making the file longer over time  if it is not deleted.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(strBuilder.ToString());
            }
        }
    }
}
