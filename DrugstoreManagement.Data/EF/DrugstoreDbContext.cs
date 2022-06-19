using DrugstoreManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Data.EF
{
    public class DrugstoreDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DrugstoreDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);


            modelBuilder.Entity<AppConfig>()
                .HasKey(x => x.Key);
            modelBuilder.Entity<AppConfig>()
                .Property(x => x.Value).IsRequired(true);


            modelBuilder.Entity<EnterpriseInformation>()
                .Property(e => e.metaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ImportBill>()
                .Property(e => e.totalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ImportBillDetail>().HasKey(t => new { t.importBillId, t.productId });
            modelBuilder.Entity<ImportBillDetail>()
                .HasOne(e => e.ImportBill)
                .WithMany(t => t.ImportBillDetails)
                .HasForeignKey(t => t.importBillId);
            modelBuilder.Entity<ImportBillDetail>()
                .HasOne(e => e.Product)
                .WithMany(t => t.ImportBillDetails)
                .HasForeignKey(t => t.productId);

            modelBuilder.Entity<ImportBillDetail>()
                .Property(e => e.priceInput)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ImportInventoryBill>()
                .Property(e => e.totalAmountWithVat)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ImportInventoryBillDetail>().HasKey(t => new { t.ImportInventoryBillId, t.productId });
            modelBuilder.Entity<ImportInventoryBillDetail>()
                .HasOne(e => e.ImportInventoryBill)
                .WithMany(t => t.ImportInventoryBillDetails)
                .HasForeignKey(t => t.ImportInventoryBillId);
            modelBuilder.Entity<ImportInventoryBillDetail>()
                .HasOne(e => e.Product)
                .WithMany(t => t.ImportInventoryBillDetails)
                .HasForeignKey(t => t.productId);

            modelBuilder.Entity<ImportInventoryBillDetail>()
                .Property(e => e.priceInput)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<PrescriptionDetail>().HasKey(t => new { t.prescriptionId, t.productId });
            modelBuilder.Entity<PrescriptionDetail>()
                .HasOne(e => e.Prescription)
                .WithMany(t => t.PrescriptionDetails)
                .HasForeignKey(t => t.prescriptionId);
            modelBuilder.Entity<PrescriptionDetail>()
                .HasOne(e => e.Product)
                .WithMany(t => t.PrescriptionDetails)
                .HasForeignKey(t => t.productId);

            modelBuilder.Entity<Product>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.metaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.batchNo)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.metaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(e => e.idCategory);

            modelBuilder.Entity<ImportBill>()
                .HasOne(x => x.Supplier).WithMany(x => x.ImportBills).HasForeignKey(e => e.supplierId);

            modelBuilder.Entity<Supplier>()
                .HasOne(x => x.SupplierRole).WithMany(x => x.Suppliers).HasForeignKey(e => e.SupplierRoleId);

            modelBuilder.Entity<UnitPrice>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 0);
            modelBuilder.Entity<Invoice>()
                .Property(e => e.TotalAmountAfterDiscount)
                .HasPrecision(18, 0);
            modelBuilder.Entity<Invoice>()
                .Property(e => e.DiscountAmount)
                .HasPrecision(18, 0);
        }
        public virtual DbSet<AppConfig> AppConfigs { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EnterpriseInformation> EnterpriseInformations { get; set; }
        public virtual DbSet<ImportBill> ImportBills { get; set; }
        public virtual DbSet<ImportBillDetail> ImportBillDetails { get; set; }
        public virtual DbSet<ImportInventoryBill> ImportInventoryBills { get; set; }
        public virtual DbSet<ImportInventoryBillDetail> ImportInventoryBillDetails { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierRole> SupplierRoles { get; set; }
        public virtual DbSet<UnitName> UnitNames { get; set; }
        public virtual DbSet<UnitPrice> UnitPrices { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

    }
}
