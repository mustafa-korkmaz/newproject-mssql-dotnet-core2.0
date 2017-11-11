using Dto;

namespace Security
{
    public interface ISecurity
    {
        string GetToken(ApplicationUser identity, string password);
    }
}
