using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Common;
using Common.Response;
using Dto;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Services.Email;

namespace Security.Jwt
{
    public class JwtSecurity : ISecurity
    {
        private readonly UserManager<Dal.Models.Identity.ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        public JwtSecurity(UserManager<Dal.Models.Identity.ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<SecurityResponse<string>> GetToken(ApplicationUser userDto, string password)
        {
            var resp = new SecurityResponse<string>
            {
                ResponseCode = ResponseCode.Fail
            };

            Dal.Models.Identity.ApplicationUser user;

            if (userDto.UserName.Contains("@")) // login via email
            {
                user = await _userManager.FindByEmailAsync(userDto.Email);
            }
            else // login via username
            {
                user = await _userManager.FindByNameAsync(userDto.UserName);
            }

            if (user == null)
            {
                resp.ResponseMessage = ErrorMessage.UserNotFound;
                return resp;
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                resp.ResponseMessage = ErrorMessage.UserNotFound;
                return resp;
            }

            //todo: get claims async
            //todo: get roles async

            userDto.Email = user.Email;
            userDto.Id = user.Id;

            var token = GenerateToken(userDto);

            resp.ResponseData = token;
            resp.ResponseCode = ResponseCode.Success;

            return resp;
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

        public async Task<SecurityResponse> Reset(string emailOrUsername)
        {
            var resp = new SecurityResponse
            {
                ResponseCode = ResponseCode.Fail
            };

            Dal.Models.Identity.ApplicationUser user;

            if (emailOrUsername.Contains("@")) // find via email
            {
                user = await _userManager.FindByEmailAsync(emailOrUsername);
            }
            else // find via username
            {
                user = await _userManager.FindByNameAsync(emailOrUsername);
            }

            if (user == null)
            {
                resp.ResponseMessage = ErrorMessage.UserNotFound;
                return resp;
            }

            await _emailService.SendEmailAsync(user.Email, "reminder", "reminder_link");

            resp.ResponseCode = ResponseCode.Success;

            return resp;
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
    }
}


