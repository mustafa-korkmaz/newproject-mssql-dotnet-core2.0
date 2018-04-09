using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Security;
using Security.Jwt;
using Dto;
using Dal;

namespace Security.Jwt
{
    public class JwtSecurity : ISecurity
    {
        private readonly UnitOfWork _uow;
        //private readonly IRepository _userRepository;
        public JwtSecurity(BlogDbContext context)
        {
            this._uow = new UnitOfWork(context);
            var repository = _uow.Repository<Dal.Models.Post>();
        }

        public string GetToken(ApplicationUser identity, string password)
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
            return this.GenerateToken(identity);
            //   return null;
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
