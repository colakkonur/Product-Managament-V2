#nullable disable

using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure.Contexts
{
    public partial class ProductManagementDbContext : DbContext
    {
        public ProductManagementDbContext()
        {
        }

        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.MainCategoryId, "MainCategoryId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.MainCategoryId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MainCategory)
                    .WithMany(p => p.InverseMainCategory)
                    .HasForeignKey(d => d.MainCategoryId)
                    .HasConstraintName("categories_ibfk_1");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("companies");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FullAdress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("prices");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DiscountRate).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Margin).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Price1)
                    .HasColumnName("Price")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ShippingCost).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TaxRate).HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.CategoryId, "CategoryId");

                entity.HasIndex(e => e.CompanyId, "CompanyId");

                entity.HasIndex(e => e.ImagesId, "ImagesId");

                entity.HasIndex(e => e.PricesId, "PricesId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImagesId)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PricesId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tags)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_1");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("products_ibfk_4");

                entity.HasOne(d => d.Images)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ImagesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("products_ibfk_3");

                entity.HasOne(d => d.Prices)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PricesId)
                    .HasConstraintName("products_ibfk_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.CompanyId, "CompanyId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NameSurname)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Position)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("users_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
