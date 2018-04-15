﻿using System.Linq;
using Business.Interfaces;
using Dal;
using Services.Caching;

namespace Business
{
    public class PostBusiness : IPostBusiness
    {
        private readonly UnitOfWork _uow;

        public PostBusiness(BlogDbContext context)
        {
            _uow = new UnitOfWork(context);
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
