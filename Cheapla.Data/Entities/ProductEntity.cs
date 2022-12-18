using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? UnitPrice { get; set; }

        public int UnitInStock { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        public string Summary { get; set; }


        public List<CartItemEntity> CartItems { get; set; }


        public CategoryEntity Category { get; set; }

        public List<CommentEntity> comments { get; set; }



    }

    public class ProductEntityConfiguration : BaseConfiguration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

            builder.Property(x => x.Description).IsRequired(false);

            builder.Property(x => x.UnitPrice).IsRequired(false);

            builder.Property(x => x.UnitInStock).IsRequired();

            builder.Property(x => x.ImagePath).IsRequired(false);

            builder.Property(x => x.CategoryId).IsRequired();

            builder.Property(x => x.Summary).IsRequired(false);







            base.Configure(builder);
        }
    }
}
