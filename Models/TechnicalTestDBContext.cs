using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd.Models
{
    public partial class TechnicalTestDBContext : DbContext
    {
        public TechnicalTestDBContext()
        {
        }

        public TechnicalTestDBContext(DbContextOptions<TechnicalTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=TechnicalTest;user id=mario;password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasComment("Tabla en donde se almacenan los cliente");

                entity.Property(e => e.Id).HasComment("Identificador del registro");

                entity.Property(e => e.Age).HasComment("Edad cliente");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Código cliente");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre cliente");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasComment("Tabla en donde se almacenan las facturas de venta");

                entity.Property(e => e.Id).HasComment("Identificador del registro");

                entity.Property(e => e.InvoiceNumber).HasComment("Número de la factura");

                entity.Property(e => e.CustomerId).HasComment("Id del cliente");

                entity.Property(e => e.ProductId).HasComment("Id del producto");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de compra");

                entity.Property(e => e.Quantity).HasComment("Cantidad");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Customer");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasComment("Tabla en donde se almacenan los productos");

                entity.Property(e => e.Id).HasComment("Identificador del registro");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Código del producto");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre del producto");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasComment("Precio producto");

                entity.Property(e => e.SupplierId).HasComment("Id del proveedor");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Supplier");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.HasComment("Tabla en donde se almacenan los proveedores");

                entity.Property(e => e.Id).HasComment("Identificador del registro");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Código del proveedor");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre del proveedor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
