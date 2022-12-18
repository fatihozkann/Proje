using Cheapla.Data.Dto;
using Cheapla.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cheapla.WebUI.Models
{
    public class ChangePasswordViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Güncel Şifrenizi Giriniz")]
        [Required(ErrorMessage = "Lütfen Güncel Şifrenizi Giriniz")]
        public string LastPassword { get; set; }



        [Display(Name = "lütfen Yeni Şifrenizi Giriniz")]
        [Required(ErrorMessage = "Lütfen Yeni Şifrenizi Giriniz")]
        public string Password { get; set; }



        [Display(Name = "şifre (Tekrar)")]
        [Required(ErrorMessage = "Lütfen  Şifrenizi Tekrar Giriniz")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler Eşleşmiyor!")]
        public string PasswordConfirm { get; set; }
    }
}
