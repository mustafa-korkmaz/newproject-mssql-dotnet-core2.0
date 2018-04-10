namespace Common.Response
{
    /// <summary>
    /// response class between web api and api service integration layer
    /// </summary>
    public class ServiceResponse<T> : BaseResponse
    {
        public ResponseCode ResponseCode { get; set; }

        public T ResponseData { get; set; }
    }

}