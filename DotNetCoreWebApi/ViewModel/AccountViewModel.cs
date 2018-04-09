﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
