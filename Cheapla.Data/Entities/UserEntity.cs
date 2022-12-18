using Cheapla.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public UserTypeEnum UserType { get; set; }

        public List<CartEntity> Carts { get; set; }

        public List<CommentEntity> Comments { get; set; }

    }

    public class UserEntityConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(75);

            builder.Property(x => x.Password).IsRequired();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(35);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(35);

            builder.Property(x => x.Address).IsRequired(false);

            builder.Property(x => x.City).IsRequired(false);






            base.Configure(builder);
        }
    }
}
