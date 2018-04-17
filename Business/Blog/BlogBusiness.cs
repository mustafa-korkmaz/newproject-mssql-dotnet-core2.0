using System.Collections.Generic;
using AutoMapper;
using Dal;
using Dal.Repositories.Blog;
using Services.Logging;

namespace Business.Blog
{
    public class BlogBusiness : IBlogBusiness
    {
        private readonly UnitOfWork _uow;
        private readonly IBlogRepository _repository;
        protected readonly IMapper Mapper;
        protected readonly ILogService LogService;

        public BlogBusiness(BlogDbContext context, ILogService logService, IMapper mapper)
        {
            _uow = new UnitOfWork(context);
            _repository = _uow.Repository<BlogRepository, Dal.Models.Blog>();
            LogService = logService;
            Mapper = mapper;
        }

        public IEnumerable<Dto.Blog> SearchBlogs(string url)
        {
            var blogs = _repository.SearchBlogs(url);

            var dtos = Mapper.Map<IEnumerable<Dal.Models.Blog>, IEnumerable<Dto.Blog>>(blogs);

            return dtos;
        }

        public Dto.Blog Get(int id)
        {
            var blog = _repository.GetById(id);

            var dto = Mapper.Map<Dal.Models.Blog, Dto.Blog>(blog);

            return dto;
        }
    }
}
