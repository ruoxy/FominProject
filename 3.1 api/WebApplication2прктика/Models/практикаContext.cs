using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2прктика.Models
{
    public partial class практикаContext : DbContext
    {
        public практикаContext()
        {
        }

        public практикаContext(DbContextOptions<практикаContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<DescriptionProduct> DescriptionProducts { get; set; } = null!;
        public virtual DbSet<Filterr> Filterrs { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KV15JED ;Database=практика; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BookingAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("booking_adress");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("booking_status");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Delivery)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("delivery");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__cart_id__36B12243");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__customer_i__300424B4");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CartId })
                    .HasName("PK__CartItem__25ED2F579B6F05C7");

                entity.ToTable("CartItem");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__cart_i__33D4B598");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__produc__32E0915F");
            });

            modelBuilder.Entity<DescriptionProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CustomerId })
                    .HasName("PK__Descript__0BD4214D7D4FD52A");

                entity.ToTable("DescriptionProduct");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.TextD)
                    .HasMaxLength(436)
                    .IsUnicode(false)
                    .HasColumnName("text_d");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DescriptionProducts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Descripti__custo__2D27B809");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DescriptionProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Descripti__produ__2C3393D0");
            });

            modelBuilder.Entity<Filterr>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Filterr__D54EE9B414A0BC9D");

                entity.ToTable("Filterr");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.Popular).HasColumnName("popular");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.Property(e => e.Sale).HasColumnName("sale");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductAvailability).HasColumnName("product_availability");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__categor__29572725");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserEmail, "UQ__Users__B0FBA212CAC9981D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserPassord)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_passord");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
