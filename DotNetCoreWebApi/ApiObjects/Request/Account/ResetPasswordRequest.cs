using System.ComponentModel.DataAnnotations;

namespace WebApi.ApiObjects.Request.Account
{
    public class ResetPasswordRequest
    {
        [Required]
        public string EmailOrUsername { get; set; }
    }
}
