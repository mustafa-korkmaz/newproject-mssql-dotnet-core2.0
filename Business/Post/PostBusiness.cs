using System.Linq;
using Dal;
using Services.Caching;
using AutoMapper;
using Services.Logging;
using Dto;

namespace Business.Post
{
    public class PostBusiness : CrudBusiness<Dal.Models.Post, Dto.Post>, IPostBusiness
    {
        public PostBusiness(BlogDbContext context, ILogService logService, IMapper mapper)
        : base(context, logService, mapper)
        {
        }

        [CacheableResult(Provider = "LocalMemoryCacheService", ExpireInMinutes = 10)]
        public string GetContent(int id)
        {
            var repository = _uow.Repository<Dal.Models.Post>();

            var post = repository.AsQueryable(p => p.Id == id)
                .FirstOrDefault();

            return post?.Content;
        }
    }
}
