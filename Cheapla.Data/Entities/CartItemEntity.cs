using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Entities
{
    public class CartItemEntity : BaseEntity
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }

        public int Quantity { get; set; }

        public CartEntity Cart { get; set; }

        public ProductEntity Product { get; set; }
    }
    public class CartItemEntityConfiguration : BaseConfiguration<CartItemEntity>
    {
        public override void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {

            base.Configure(builder);

            builder.Ignore("Id");
            builder.HasKey("CartId", "ProductId");
            builder.HasOne(x => x.Cart).WithMany(x => x.CartItems).HasForeignKey(x => x.CartId);
            builder.HasOne(x => x.Product).WithMany(x => x.CartItems).HasForeignKey(x => x.ProductId);
        }

    }
}
