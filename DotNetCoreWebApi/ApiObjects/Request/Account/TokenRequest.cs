﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.ApiObjects.Request.Account
{
    public class TokenRequest
    {
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
