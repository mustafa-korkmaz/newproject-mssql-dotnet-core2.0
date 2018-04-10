using System.Security.Claims;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Security;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using Common;
using Common.Response;
using WebApi.ApiObjects.Request.Account;
using WebApi.ApiObjects.ViewModels;

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

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public IActionResult Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var resp = RegisterUser(request);
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

        private ApiResponse<TokenViewModel> GetTokenResponse(TokenRequest request)
        {
            var apiResp = new ApiResponse<TokenViewModel>
            {
                ResponseCode = ResponseCode.Fail
            };

            var applicationUser = new ApplicationUser
            {
                Email = request.EmailOrUsername,
                UserName = request.EmailOrUsername
            };

            var securityResp = _security.GetToken(applicationUser, request.Password);

            if (securityResp.ResponseCode != ResponseCode.Success)
            {
                apiResp.ResponseMessage = securityResp.ResponseMessage;

                return apiResp;
            }

            var model = new TokenViewModel
            {
                UserName = applicationUser.UserName,
                AccessToken = securityResp.ResponseData,
                Email = applicationUser.Email,
                NameSurname = applicationUser.NameSurname,
                Id = applicationUser.Id
            };

            apiResp.ResponseData = model;
            apiResp.ResponseCode = ResponseCode.Success;

            return apiResp;
        }

        private ApiResponse<ApplicationUser> RegisterUser(RegisterRequest request)
        {
            var apiResp = new ApiResponse<ApplicationUser>
            {
                ResponseCode = ResponseCode.Fail
            };

            var applicationUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.UserName,
                NameSurname = request.NameSurname
            };

            var securityResp = _security.Register(applicationUser, request.Password);

            if (securityResp.ResponseCode != ResponseCode.Success)
            {
                apiResp.ResponseMessage = securityResp.ResponseMessage;
                return apiResp;
            }

            apiResp.ResponseData = applicationUser;
            apiResp.ResponseCode = ResponseCode.Success;

            return apiResp;
        }
    }
}
