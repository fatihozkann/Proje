using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Dto
{
    public class CommentDto
    {

      

        public int Id { get; set; }

        public string UserName { get; set; }



        public int ProductId { get; set; }

        public int UserId { get; set; }



        public string CommentContent { get; set; }



        public DateTime Date { get; set; }
    }
}
