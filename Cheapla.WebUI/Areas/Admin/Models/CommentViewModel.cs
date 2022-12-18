using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cheapla.WebUI.Areas.Admin.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }


        
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }


        public int UserId { get; set; }

        public int ProductId { get; set; }


       
        [Display(Name = "Yorum")]
        public string CommentContent { get; set; }

        public DateTime Date { get; set; }
    }
}
