using System.Net;

namespace Common.Response
{
    /// <summary>
    /// response class between internet and betblogger.WebApi
    /// all api methods must return this object
    /// </summary>
    public class ApiResponse<T> : BaseResponse
    {
        public ResponseCode ResponseCode { get; set; }

        public string ResponseText => ResponseCode.ToString("G");

        public T ResponseData { get; set; }
    }

    public class ApiResponse : BaseResponse
    {
        public ResponseCode ResponseCode { get; set; }

        public string ResponseText => ResponseCode.ToString("G");

    }

}