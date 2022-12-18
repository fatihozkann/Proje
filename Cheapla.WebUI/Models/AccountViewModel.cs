using System.ComponentModel.DataAnnotations;

namespace Cheapla.WebUI.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı Ad kısmı Boş Olamaz !")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Kullanıcı Soy Ad kısmı Boş Olamaz !")]
        [Display(Name = "Soy Ad")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Kullanıcı Eposta kısmı Boş Olamaz !")]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı adres kısmı Boş Olamaz !")]
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Kullanıcı şehir kısmı Boş Olamaz !")]
        [Display(Name = "Şehir")]
        public string City { get; set; }
    }
}
