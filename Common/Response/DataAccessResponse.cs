namespace Common.Response
{
    /// <summary>
    /// response class for DataAccess (dal) classes
    /// </summary>
    public class DataAccessResponse<T> : BaseResponse
    {
        // to do: here goes other properties for DataAccessResponse object

        public ResponseCode ResponseCode { get; set; }

        public T ResponseData { get; set; }
    }

    public class DataAccessResponse : BaseResponse
    {
        // to do: here goes other properties for DataAccessResponse object

        public ResponseCode ResponseCode { get; set; }

    }
}