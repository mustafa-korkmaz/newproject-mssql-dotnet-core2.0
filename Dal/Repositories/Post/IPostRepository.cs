using System.Collections.Generic;

namespace Dal.Repositories.Post
{
    public interface IPostRepository : IRepository<Models.Post>
    {
        IEnumerable<Models.Post> SearchPosts(string title);
    }
}
