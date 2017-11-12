using System;

namespace Dto
{
    public class RequestLog : DtoBase
    {
        public string Ip { get; set; }

        public string Uri { get; set; }

        public string RequestContent { get; set; }

        public int HttpResponseCode { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
