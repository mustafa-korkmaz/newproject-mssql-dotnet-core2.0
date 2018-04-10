using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Common;
using Common.Response;
using Security;
using Security.Jwt;
using Dto;
using Dal;

namespace Security.Jwt
{
    public class JwtSecurity : ISecurity
    {
        private readonly UnitOfWork _uow;
        private readonly IRepository<Dal.Models.Identity.ApplicationUser> _userRepository;

        public JwtSecurity(BlogDbContext context)
        {
            _uow = new UnitOfWork(context);
            _userRepository = _uow.Repository<Dal.Models.Identity.ApplicationUser>();
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

        public SecurityResponse Register(ApplicationUser userDto, string password)
        {
            var resp = new SecurityResponse { ResponseCode = ResponseCode.Fail };

            bool userExists;

            userExists = _userRepository.AsQueryable().Any(u => u.UserName == userDto.UserName || u.Email == userDto.Email);

            if (userExists)
            {
                resp.ResponseMessage = ErrorMessage.UserExists;
                return resp;
            }

            //var userModel = new ApplicationUser
            //{
            //    CreatedAt = Statics.GetTurkeyCurrentDateTime(),
            //    NameSurname = userDto.NameSurname,
            //    Email = userDto.Email ?? "",
            //    EmailConfirmed = userDto.EmailConfirmed,
            //    UserName = userDto.UserName,
            //    Status = userDto.Status,
            //    ImageName = userDto.ImageName,
            //    TwoFactorEnabled = userDto.ContactPermission, // contact permission field matched with twoFactorEnabled column
            //    PasswordHash = HashPassword(password),
            //    SecurityStamp = Guid.NewGuid().ToString()
            //};

            //_db.Users.Add(userModel);

            //_db.SaveChanges();

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

    }
}


