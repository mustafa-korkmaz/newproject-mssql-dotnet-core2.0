using System.Security.Claims;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security;
using Security.Jwt;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using WebApi.ApiObjects.Request;
using WebApi.ApiObjects.Response;

namespace WebApi.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        private readonly ISecurity _security;
        public AccountController(ISecurity security)
        {
            _security = security;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public IActionResult GetToken([FromBody]TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var resp = GetTokenResponse(request);
            return Ok(resp);
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

        /// <summary>
        /// return model state errors as a sentence.
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        private string GetModelStateErrors(ModelStateDictionary dic)
        {
            var list = dic.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

            string result = string.Empty;

            for (int i = 1; i <= list.Count(); i++)
            {
                result += list[i - 1];

                if (i < list.Count())
                {
                    result += " ";
                }
            }

            return result.Trim();
        }


        private TokenResponse GetTokenResponse(TokenRequest request)
        {
            var applicationUser = new ApplicationUser
            {
                Email = request.EmailOrUsername,
                UserName = request.EmailOrUsername
            };

            var token = _security.GetToken(applicationUser, request.Password);

            return new TokenResponse
            {
                UserName = applicationUser.UserName,
                AccessToken = token,
                Email = applicationUser.Email,
                NameSurname = applicationUser.NameSurname,
                Id = applicationUser.Id
            };
        }
    }
}
