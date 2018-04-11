using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Common;
using Common.Response;
using Dto;
using Dal;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Security.Jwt
{
    public class JwtSecurity : ISecurity
    {
        private readonly UserManager<Dal.Models.Identity.ApplicationUser> _userManager;
        public JwtSecurity(UserManager<Dal.Models.Identity.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public SecurityResponse<string> GetToken(ApplicationUser userDto, string password)
        {
            //todo: get user
            //todo: get claims async
            //todo: get roles async
            //var existUser = userRepository.Login(identity.Email, password);

            //if (existUser != null)
            //{
            //    return this.GenerateToken(existUser);
            //}
            // else 


            var token = GenerateToken(userDto);

            return new SecurityResponse<string>
            {
                ResponseData = token,
                ResponseCode = ResponseCode.Success
            };
            //   return null;
        }

        public async Task<SecurityResponse> Register(ApplicationUser userDto, string password)
        {
            var resp = new SecurityResponse { ResponseCode = ResponseCode.Fail };

            var userByName = await _userManager.FindByNameAsync(userDto.UserName);

            if (userByName != null)
            {
                resp.ResponseMessage = ErrorMessage.UserExists;
                return resp;
            }

            var userByEmail = await _userManager.FindByEmailAsync(userDto.Email);

            if (userByEmail != null)
            {
                resp.ResponseMessage = ErrorMessage.UserExists;
                return resp;
            }

            var userModel = new Dal.Models.Identity.ApplicationUser
            {
                //CreatedAt = DateTime.UtcNow,
                //NameSurname = userDto.NameSurname,
                Email = userDto.Email ?? "",
                EmailConfirmed = userDto.EmailConfirmed,
                UserName = userDto.UserName,
                //Status = userDto.Status,
                //ImageName = userDto.ImageName,
                PasswordHash = HashPassword(password),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            await _userManager.CreateAsync(userModel);

            userDto.Id = userModel.Id;

            resp.ResponseCode = ResponseCode.Success;

            return resp;

        }

        public SecurityResponse Remind(string emailOrUsername)
        {
            throw new NotImplementedException();
        }


        private string GenerateToken(ApplicationUser user)
        {
            var handler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Id", "fsfsdf"));// user.Id));
            //foreach(var userRole in user.UserRoles)
            //{
            //    claims.Add(new Claim(userRole.Role.Description, user.ID.ToString()));
            //}

            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.Email, "Token"), claims);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = JwtTokenConstants.Issuer,
                Audience = JwtTokenConstants.Audience,
                SigningCredentials = JwtTokenConstants.SigningCredentials,
                Subject = identity,
                Expires = DateTime.Now.Add(JwtTokenConstants.TokenExpirationTime),
                NotBefore = DateTime.Now
            });


            return handler.WriteToken(securityToken);
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        /// <summary>
        /// Finds a user by email. Returns null if user not exists
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private ApplicationUser FindByEmail(string email, string password)
        {
            var passwordHash = HashPassword(password);
            // var user = _userRepository.AsQueryable(p => p.Email == email && p.PasswordHash == passwordHash);

            return null;
        }

        /// <summary>
        /// Finds a user. Returns null if user not exists
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private ApplicationUser Find(string username, string password)
        {
            var passwordHash = HashPassword(password);
            // var user = _userRepository.AsQueryable(p => p.UserName == username && p.PasswordHash == passwordHash);

            return null;
        }

        /// <summary>
        /// Creates a new user. Sets user null if user creation fails
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private void Create(ApplicationUser user, string password)
        {

        }

    }
}


