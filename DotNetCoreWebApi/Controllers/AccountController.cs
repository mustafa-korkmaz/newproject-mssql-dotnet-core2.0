using System.Security.Claims;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security;
using Security.Jwt;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        //DaoContext context;
        //public LoginController(DaoContext daoContext)
        //{
        //    this.context = daoContext;
        //}

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public string GetToken([FromBody]LoginViewModel model)
        {
            //todo: check model isValid
            var applicationUser = new ApplicationUser
            {
                Email = model.Email
            };

            // ISecurity security = new JwtSecurity(context);
            ISecurity security = new JwtSecurity();
            return JsonConvert.SerializeObject(new
            {
                token = security.GetToken(applicationUser, model.Password),
                user = applicationUser
            });
        }


        [HttpGet]
        [Route("user")]
        public string GetUser()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            return JsonConvert.SerializeObject(new
            {
                UserName = claimsIdentity.Name
            });
        }
    }
}
