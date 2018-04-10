using System.Net;

namespace Common.Response
{
    /// <summary>
    /// response class between web Controllers and api classes
    /// </summary>
    public class HttpClientResponse<T> : BaseResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public T ResponseData { get; set; }
    }

}