
using System;

namespace WebApi.ApiObjects.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string NameSurname { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
