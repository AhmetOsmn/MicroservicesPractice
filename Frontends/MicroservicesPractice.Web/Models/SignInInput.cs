using System.ComponentModel.DataAnnotations;

namespace MicroservicesPractice.Web.Models
{
    public class SignInInput
    {
        [Display(Name = "Email Adresi")]
        public string Email { get; set; } = null!;

        [Display(Name = "Şifre")]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla")]
        public bool IsRemember { get; set; }
    }
}
