
namespace WebApi.ApiObjects.ViewModels
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }

        public string ExpiresIn { get; set; }

        public string NameSurname { get; set; }

        public string UserName { get; set; }

        public string Id { get; set; }

        public string UserRoles { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string CreatedAt { get; set; }
    }
}
