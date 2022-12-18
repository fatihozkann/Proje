using Cheapla.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Data.Contexts
{
    public class CheaplaContext : DbContext
    {
        public CheaplaContext(DbContextOptions<CheaplaContext> options) : base(options)
        {


        }



        public DbSet<UserEntity> Users => Set<UserEntity>();

        public DbSet<ProductEntity> Products => Set<ProductEntity>();

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

        public DbSet<CartEntity> Carts => Set<CartEntity>();

        public DbSet<CartItemEntity> CartItems => Set<CartItemEntity>();

        public DbSet<CommentEntity> Comments => Set<CommentEntity>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CartEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CartItemEntityConfiguration());

            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());


            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
                {
                new UserEntity()
                {
                    Id = 1,
                    FirstName = "Fatih",
                    LastName = "Admin",
                    Email = "AdminFatih@hotmail.com",
                    Password = "123456",
                    UserType = Enums.UserTypeEnum.admin,
                },
                new UserEntity()
                {
                    Id=2,
                    FirstName = "Kullanici",
                    LastName = "KullaniciSoyad",
                    Email = "kullanici@bilgeadam.com",
                    Password = "654321",
                    UserType = Enums.UserTypeEnum.user
                }

            });




            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

}

