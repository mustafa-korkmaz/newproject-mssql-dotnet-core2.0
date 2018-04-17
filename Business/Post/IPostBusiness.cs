
using System.Collections.Generic;

namespace Business.Post
{
    public interface IPostBusiness : ICrudBusiness<Dal.Models.Post, Dto.Post>
    {
        IEnumerable<Dto.Post> SearchPosts(string title);
    }
}
