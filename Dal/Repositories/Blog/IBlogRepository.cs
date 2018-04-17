using System.Collections.Generic;

namespace Dal.Repositories.Blog
{
    public interface IBlogRepository : IRepository<Models.Blog>
    {
        IEnumerable<Models.Blog> SearchBlogs(string url);
    }
}
