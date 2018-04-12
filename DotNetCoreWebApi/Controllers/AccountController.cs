using System.Security.Claims;
using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using Common;
using Common.Response;
using WebApi.ApiObjects.Request.Account;
using WebApi.ApiObjects.ViewModels;
using System.Threading.Tasks;

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

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken([FromBody]TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var resp = await GetTokenResponse(request);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        [HttpPost("reset")]
        [AllowAnonymous]
        public async Task<IActionResult> Reset([FromBody]ResetPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var resp = await ResetPassword(request);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(GetModelStateErrors(ModelState));
            }

            var resp = await RegisterUser(request);

            if (resp.ResponseCode != ResponseCode.Success)
            {
                return BadRequest(resp.ResponseMessage);
            }

            return Ok(resp);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _security.GetUser(User);

            return Ok(user);
        }


        #region private methods
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

        private async Task<ApiResponse<TokenViewModel>> GetTokenResponse(TokenRequest request)
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

            var securityResp = await _security.GetToken(applicationUser, request.Password);

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

        private async Task<ApiResponse<ApplicationUser>> RegisterUser(RegisterRequest request)
        {
            var apiResp = new ApiResponse<ApplicationUser>
            {
                ResponseCode = ResponseCode.Fail
            };

            var applicationUser = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Username,
                NameSurname = request.NameSurname
            };

            var securityResp = await _security.Register(applicationUser, request.Password);

            if (securityResp.ResponseCode != ResponseCode.Success)
            {
                apiResp.ResponseMessage = securityResp.ResponseMessage;
                return apiResp;
            }

            apiResp.ResponseData = applicationUser;
            apiResp.ResponseCode = ResponseCode.Success;

            return apiResp;
        }

        private async Task<ApiResponse> ResetPassword(ResetPasswordRequest request)
        {
            var apiResp = new ApiResponse
            {
                ResponseCode = ResponseCode.Fail
            };

            var securityResp = await _security.Reset(request.EmailOrUsername);

            if (securityResp.ResponseCode != ResponseCode.Success)
            {
                apiResp.ResponseMessage = securityResp.ResponseMessage;

                return apiResp;
            }

            apiResp.ResponseCode = ResponseCode.Success;

            return apiResp;
        }

        #endregion private methods
    }
}
