using Common.Response;
using Dto;

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
        SecurityResponse<string> GetToken(ApplicationUser userDto, string password);

        /// <summary>
        /// Creates user and sets user info
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        SecurityResponse Register(ApplicationUser userDto, string password);

        SecurityResponse Remind(string emailOrUsername);
    }
}
