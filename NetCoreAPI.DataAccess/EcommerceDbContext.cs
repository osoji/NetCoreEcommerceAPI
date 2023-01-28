using Microsoft.EntityFrameworkCore;
using NetCoreAPI.Entities;
using System.Diagnostics;

namespace NetCoreAPI.DataAccess
{
    public partial class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) 
            : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Category Configuration
            modelBuilder.Entity<Category>(entity => {

                entity.HasKey(x => x.CategoryId);

                entity.Property(x => x.CategoryName)
                .IsRequired().HasMaxLength(250);

                entity.Property(x => x.CategoryDescription)
                .IsRequired(false)
                .HasMaxLength(1000);

                entity.Property(x=>x.CategorySlug).IsRequired()
                      .HasMaxLength(700);

                entity.HasOne(x=>x.ParentCategory)
                .WithMany(x=>x.ChildrenCategories)
                .HasForeignKey(x=>x.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);                
            
            });


            //Product

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId);
                entity.Property(x => x.ProductName).IsRequired()
                .HasMaxLength(255);

                entity.Property(x=>x.Description).IsRequired(false)
                .HasMaxLength(1500);

                entity.Property(x => x.ProductSlug).IsRequired()
              .HasMaxLength(800);

                entity.Property(x=>x.UnitPrice).IsRequired()
                .HasPrecision(2);

                entity.HasMany(x => x.ProductImages).WithOne().OnDelete(DeleteBehavior.Restrict);

            });

            //ProductCategory
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(x => x.ProductCategoryId);

                entity.HasOne(x => x.Category)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Product)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            });

            //ProductImage
            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(x => x.ProductImageId);
                entity.Property(x => x.ImageName).IsRequired();
                entity.Property(x => x.ImagePath).IsRequired()
                .HasMaxLength(255);
                entity.Property(x => x.Decription).IsRequired(false)
                .HasMaxLength(1500);
                entity.HasOne(x => x.Product)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);





    }
}