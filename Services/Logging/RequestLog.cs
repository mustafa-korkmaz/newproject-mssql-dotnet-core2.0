using System;

namespace Services.Logging
{
    public class RequestLog
    {
        public string Ip { get; set; }

        public string Uri { get; set; }

        public string RequestContent { get; set; }

        public int HttpResponseCode { get; set; }
    }
}
