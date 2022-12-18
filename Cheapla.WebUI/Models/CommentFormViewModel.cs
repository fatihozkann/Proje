using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cheapla.WebUI.Models
{
    public class CommentFormViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Kullanıcı Adı kısmı Boş Olamaz !")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }


        public int UserId { get; set; }

        public int ProductId { get; set; }


        [Required(ErrorMessage = "yorum  kısmı Boş Olamaz !")]
        [Display(Name = "Yorum")]
        public string CommentContent { get; set; }

        public DateTime Date { get; set; }
    }
}
