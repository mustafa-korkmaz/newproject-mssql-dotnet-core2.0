namespace Common.Response
{
    /// <summary>
    /// response class for business classes
    /// </summary>
    public class BusinessResponse<T> : BaseResponse
    {
        // to do: here goes other properties for BusinessResponse object

        public ResponseCode ResponseCode { get; set; }

        public T ResponseData { get; set; }
    }

    public class BusinessResponse : BaseResponse
    {
        // to do: here goes other properties for BusinessResponse object
        public ResponseCode ResponseCode { get; set; }
    }
}