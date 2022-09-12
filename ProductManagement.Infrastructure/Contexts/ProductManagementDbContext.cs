using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductManagement.Domain.Entities;

#nullable disable

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
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=94.73.146.49;password=jTy1B3n2.D6_:=gP;user id=u8425942_prod;database=u8425942_prod;");
            }
        }

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

                entity.HasIndex(e => e.ImagesId, "ImagesId");

                entity.HasIndex(e => e.PricesId, "PricesId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImagesId).HasColumnType("int(11)");

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

                entity.HasOne(d => d.Images)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ImagesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_2");

                entity.HasOne(d => d.Prices)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PricesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_ibfk_3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
