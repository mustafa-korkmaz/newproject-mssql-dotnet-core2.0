using System.Linq;
using Business.Interfaces;
using Dal;
using System.Collections.Generic;
using Dto;
using System;
using Business.Caching;

namespace Business
{
    public class CommonBusiness : ICommonBusiness
    {
        public CommonBusiness()
        {

        }

        [CacheableResult(Provider = "LocalMemoryCacheProvider", ExpireInMinutes = 10)]
        public IEnumerable<Category> GetCategories(int id)
        {
            return new List<Category>
               {
                   new Category {
                   Name ="Cat1",
                   Desc ="Cat1 desc",
                   CreatedAt = DateTime.Now
                   },
                   new Category {
                   Name ="Cat2",
                   Desc ="Cat2 desc",
                   CreatedAt = DateTime.Now
                   },
                   new Category {
                   Name ="Cat3",
                   Desc ="Cat3 desc",
                   CreatedAt = DateTime.Now
                   },
               };
        }
    }
}
