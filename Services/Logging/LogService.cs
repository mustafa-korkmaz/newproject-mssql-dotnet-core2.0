using System;
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
            var infoLoggingPath = _basePath + _appSettings.Value.Logging.InfoPath;

            var logTemplate = new LogTemplate(logType)
            {
                Message = message,
                Object = obj,
            };

            WriteLog(infoLoggingPath, _appSettings.Value.Logging.InfoFile, logTemplate);

        }

        public void LogException(Exception exc)
        {
            var errorLoggingPath = _basePath + _appSettings.Value.Logging.ErrorPath;

            var logTemplate = new LogTemplate(LogType.Error)
            {
                Message = exc.Message,
                Object = exc.StackTrace
            };

            WriteLog(errorLoggingPath, _appSettings.Value.Logging.ErrorFile, logTemplate);
        }

        public void LogRequest(RequestLog requestLog)
        {
            var requestLoggingPath = _basePath + _appSettings.Value.Logging.ReqAndRespPath;

            var logTemplate = new LogTemplate(LogType.ReqAndResp)
            {
                Message = requestLog.HttpResponseCode.ToString(),
                Object = requestLog.RequestContent
            };

            WriteLog(requestLoggingPath, _appSettings.Value.Logging.ReqAndRespFile, logTemplate);
        }

        private void WriteLog(string filePath, string fileName, LogTemplate template)
        {
            var objStr = template.Object != null ? JsonConvert.SerializeObject(template.Object, Formatting.Indented) : "null";

            if (objStr.Contains("password"))
            {
                //do not log password included reqs
                objStr = "protected_content";
            }

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

            //add end-of-log
            strBuilder.Append("\n##########");

            var fullPath = string.Format(filePath, template.DateFolderName, template.HourFolderName);

            Directory.CreateDirectory(fullPath);

            // This text is always added, making the file longer over time  if it is not deleted.
            using (StreamWriter sw = File.AppendText(fullPath + "/" + fileName))
            {
                sw.WriteLine(strBuilder.ToString());
            }
        }
    }
}
