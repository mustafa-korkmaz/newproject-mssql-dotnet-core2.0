
namespace Common
{
    /// <summary>
    /// appsettings.json file model class
    /// </summary>
    public class AppSettings
    {
        public string ApiUrl { get; set; }

        public string InfoLoggingPath { get; set; }

        public string ErrorLoggingPath { get; set; }

        public string ReqAndRespLoggingPath { get; set; }
    }
}
