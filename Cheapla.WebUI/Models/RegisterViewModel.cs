using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cheapla.WebUI.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Kullanıcı Ad kısmı Boş Olamaz !")]
        public string FirstName { get; set; }
        [Display(Name = "Soy Ad")]
        [Required(ErrorMessage = "Kullanıcı Soy Ad kısmı Boş Olamaz !")]
        public string LastName { get; set; }
        [Display(Name = "Eposta")]
        [Required(ErrorMessage = "Kullanıcı Eposta kısmı Boş Olamaz !")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Kullanıcı Şifre kısmı Boş Olamaz !")]
        public string Password { get; set; }

        [Display(Name = "Şifre (Tekrar)")]
        [Required(ErrorMessage = " !")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler Eşleşmiyor!")]
        public string PasswordConfirm { get; set; }
    }
}
