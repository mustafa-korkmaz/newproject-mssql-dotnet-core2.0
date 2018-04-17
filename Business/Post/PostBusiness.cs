using System.Collections.Generic;
using System.Linq;
using Dal;
using AutoMapper;
using Dal.Repositories.Post;
using Services.Logging;

namespace Business.Post
{
    public class PostBusiness : CrudBusiness<PostRepository, Dal.Models.Post, Dto.Post>, IPostBusiness
    {
        public PostBusiness(BlogDbContext context, ILogService logService, IMapper mapper)
        : base(context, logService, mapper)
        {
        }

        //[CacheableResult(Provider = "LocalMemoryCacheService", ExpireInMinutes = 10)]
        public IEnumerable<Dto.Post> SearchPosts(string title)
        {
            var posts = Repository.SearchPosts(title);

            var dtos = Mapper.Map<IEnumerable<Dal.Models.Post>, IEnumerable<Dto.Post>>(posts);

            return dtos;
        }
    }
}
