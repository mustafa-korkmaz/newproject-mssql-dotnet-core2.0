
using System.Collections.Generic;

namespace Business.Blog
{
    public interface IBlogBusiness
    {
        IEnumerable<Dto.Blog> SearchBlogs(string url);

        Dto.Blog Get(int id);
    }
}
