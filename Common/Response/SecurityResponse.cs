namespace Common.Response
{
    /// <summary>
    /// response class for Security classes
    /// </summary>
    public class SecurityResponse<T> : BaseResponse
    {
        // to do: here goes other properties for BusinessResponse object

        public ResponseCode ResponseCode { get; set; }

        public T ResponseData { get; set; }
    }

    public class SecurityResponse : BaseResponse
    {
        // to do: here goes other properties for BusinessResponse object
        public ResponseCode ResponseCode { get; set; }
    }
}