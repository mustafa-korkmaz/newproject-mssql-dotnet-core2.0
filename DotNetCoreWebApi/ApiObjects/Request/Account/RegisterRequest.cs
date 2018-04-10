using System.ComponentModel.DataAnnotations;

namespace WebApi.ApiObjects.Request.Account
{
    /// <summary>
    /// User registration model class
    /// </summary>
    public class RegisterRequest
    {
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Geçerli bir email adresi giriniz.")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Email { get; set; }

        [Display(Name = "İsim Soy isim")]
        public string NameSurname { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "{0} alanı için sadece alfa numerik ve alt çizgi karakteri girebilirisiniz.")]
        [StringLength(15, ErrorMessage = "{0} alanı en az {2} en çok {1} karakter olmalıdır.", MinimumLength = 4)]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "{0} alanı en az {2} en çok {1} karakter olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }

}
