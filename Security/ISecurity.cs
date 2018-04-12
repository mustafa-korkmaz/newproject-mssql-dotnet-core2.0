using System.Security.Claims;
using Common.Response;
using Dto;
using System.Threading.Tasks;

namespace Security
{
    public interface ISecurity
    {
        /// <summary>
        /// Checks for user by username or email. Sets user info and returns a valid token
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<SecurityResponse<string>> GetToken(ApplicationUser userDto, string password);

        /// <summary>
        /// Creates user and sets user info
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<SecurityResponse> Register(ApplicationUser userDto, string password);

        /// <summary>
        /// resets user's password by sending an email link
        /// </summary>
        /// <param name="emailOrUsername"></param>
        /// <returns></returns>
        Task<SecurityResponse> Reset(string emailOrUsername);

        /// <summary>
        /// returns current user info by user id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetUser(ClaimsPrincipal user);
    }
}
