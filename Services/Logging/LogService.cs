using Dal;
using System.Threading.Tasks;
using Dto;

namespace Services.Logging
{
    public class LogService : ILogService
    {
        private readonly UnitOfWork _uow;

        public LogService(BlogDbContext context)
        {
            _uow = new UnitOfWork(context);
        }

        public void LogRequest(RequestLog requestLog)
        {
            _uow.SaveAsync();
        }

        public Task LogRequestAsync(RequestLog requestLog)
        {
            return _uow.SaveAsync();
        }
    }
}
