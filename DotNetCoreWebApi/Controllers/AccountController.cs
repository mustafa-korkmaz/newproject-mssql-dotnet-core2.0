using System.Security.Claims;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security;
using Security.Jwt;
using WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

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
        public IActionResult GetToken([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var applicationUser = new ApplicationUser
            {
                Email = model.Email
            };

            var obj = JsonConvert.SerializeObject(new
            {
                token = _security.GetToken(applicationUser, model.Password),
                user = applicationUser
            });

            return Ok(obj);
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
    }
}
