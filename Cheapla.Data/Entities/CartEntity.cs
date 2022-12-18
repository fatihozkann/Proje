using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Entities
{
    public class CartEntity : BaseEntity
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public List<CartItemEntity> CartItems { get; set; }
        
    }
    public class CartEntityConfiguration : BaseConfiguration<CartEntity>
    {
        public override void Configure(EntityTypeBuilder<CartEntity> builder)
        {



            base.Configure(builder);
        }
    }
}
