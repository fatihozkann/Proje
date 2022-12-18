using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Entities
{
    public class CommentEntity : BaseEntity
    {

        

        public string CommentUserName { get; set; }

        public string CommentContent { get; set; }

        public DateTime Date { get; set; }


        public int UserId { get; set; }


        public int ProductId { get; set; }


        public UserEntity User { get; set; }

        public ProductEntity Product { get; set; }
    }

    public class CommentEntityConfiguration : BaseConfiguration<CommentEntity>
    {
        public override void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            

            base.Configure(builder);    
        }
    }
}
