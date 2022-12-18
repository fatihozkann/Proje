using System.ComponentModel.DataAnnotations;

namespace Cheapla.WebUI.Models
{
    public class CommentViewModel
    {
        public CommentViewModel()
        {
            Date=DateTime.Now;
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public int ProductId { get; set; }


        public string CommentContent { get; set; }

        public DateTime Date { get; set; }

    }
    
}
