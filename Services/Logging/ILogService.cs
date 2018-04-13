using Dto;
using System.Threading.Tasks;

namespace Services.Logging
{
    public interface ILogService
    {
        /// <summary>
        /// logs the given request async
        /// </summary>
        /// <returns></returns>
        Task LogRequestAsync(RequestLog requestLog);

        /// <summary>
        /// logs the given request
        /// </summary>
        /// <returns></returns>
        void LogRequest(RequestLog requestLog);

        ///// <summary>
        ///// logs the given exc async
        ///// </summary>
        ///// <returns></returns>
        //Task LogExceptionAsync(RequestLog requestLog);

        ///// <summary>
        ///// logs the given exc
        ///// </summary>
        ///// <returns></returns>
        //void LogException(RequestLog requestLog);
    }
}
