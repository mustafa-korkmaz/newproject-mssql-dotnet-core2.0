
namespace Business.Post
{
    public interface IPostBusiness : ICrudBusiness<Dal.Models.Post, Dto.Post>
    {
        string GetContent(int id);
    }
}
