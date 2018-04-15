
namespace Common
{
    /// <summary>
    /// appsettings.json file model class
    /// </summary>
    public class AppSettings
    {
        public string ApiUrl { get; set; }

        public LoggingSettings Logging { get; set; }

    }

    public class LoggingSettings
    {
        public string InfoPath { get; set; }

        public string InfoFile { get; set; }

        public string ErrorPath { get; set; }

        public string ErrorFile { get; set; }

        public string ReqAndRespPath { get; set; }

        public string ReqAndRespFile { get; set; }
    }
}
