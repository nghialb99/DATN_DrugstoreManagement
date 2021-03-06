// <auto-generated />
using System;
using DrugstoreManagement.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrugstoreManagement.Data.Migrations
{
    [DbContext(typeof(DrugstoreDbContext))]
    [Migration("20220603193423_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Account", b =>
                {
                    b.Property<string>("username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("currentLoginDevice")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("dateCreated")
                        .HasColumnType("date");

                    b.Property<int?>("employeeId")
                        .HasColumnType("int");

                    b.Property<string>("historyLogin")
                        .IsRequired()
                        .HasColumnType("xml");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("numberOfLogin")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("userRoleid")
                        .HasColumnType("int");

                    b.Property<int?>("veriCode")
                        .HasColumnType("int");

                    b.HasKey("username");

                    b.HasIndex("employeeId");

                    b.HasIndex("userRoleid");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.Property<string>("taxCode")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("birthDate")
                        .HasColumnType("date");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.Property<string>("employeeCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("idCard")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.EnterpriseInformation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("bankAccount")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("bankName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("enterpriseName")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("metaTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("taxCode")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("website")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("EnterpriseInformations");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportBill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("VAT")
                        .HasColumnType("int");

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("dateCreated")
                        .HasColumnType("date");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<string>("supplierId")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<decimal?>("totalAmount")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("id");

                    b.HasIndex("creator");

                    b.HasIndex("supplierId");

                    b.ToTable("ImportBills");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportBillDetail", b =>
                {
                    b.Property<int>("importBillId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("productId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("exchangeValue")
                        .HasColumnType("int");

                    b.Property<decimal>("priceInput")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("quantityInput")
                        .HasColumnType("int");

                    b.Property<string>("unitInput")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("importBillId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("ImportBillDetails");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportInventoryBill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("creator")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("dateCreated")
                        .HasColumnType("date");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<decimal?>("totalAmountWithVat")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.HasKey("id");

                    b.HasIndex("creator");

                    b.ToTable("ImportInventoryBills");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportInventoryBillDetail", b =>
                {
                    b.Property<int>("ImportInventoryBillId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("productId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("exchangeValue")
                        .HasColumnType("int");

                    b.Property<decimal>("priceInput")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("quantityInput")
                        .HasColumnType("int");

                    b.Property<string>("unitInput")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ImportInventoryBillId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("ImportInventoryBillDetails");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Invoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("invoiceInfo")
                        .IsRequired()
                        .HasColumnType("xml");

                    b.Property<string>("reasonDelete")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Prescription", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("dateCreated")
                        .HasColumnType("date");

                    b.Property<string>("medicalFacility")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("physician")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.PrescriptionDetail", b =>
                {
                    b.Property<int>("prescriptionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("productId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int?>("quantity")
                        .HasColumnType("int");

                    b.Property<int?>("unitNameId")
                        .HasColumnType("int");

                    b.HasKey("prescriptionId", "productId");

                    b.HasIndex("productId");

                    b.HasIndex("unitNameId");

                    b.ToTable("PrescriptionDetails");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("baseUnits")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("batchNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("component")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("dosage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("exchangeValue")
                        .HasColumnType("int");

                    b.Property<DateTime?>("expDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("idCategory")
                        .HasColumnType("int");

                    b.Property<string>("images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("inventoryNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("manDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("metaTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("moreImage")
                        .IsRequired()
                        .HasColumnType("xml");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("origin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("packagingSpecifications")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("qrCode")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("registrationNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("status")
                        .HasColumnType("int");

                    b.Property<bool?>("statusDelete")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("idCategory");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ProductCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("metaTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("ProductCategorys");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Supplier", b =>
                {
                    b.Property<string>("taxcode")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int>("SupplierRoleId")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("website")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("taxcode");

                    b.HasIndex("SupplierRoleId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.SupplierRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("dateCreated")
                        .HasColumnType("date");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.Property<string>("supplierRoleCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("SupplierRoles");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.UnitName", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("id");

                    b.ToTable("UnitNames");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.UnitPrice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("exchangeValue")
                        .HasColumnType("int");

                    b.Property<decimal?>("price")
                        .HasPrecision(18)
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("productId")
                        .HasColumnType("int");

                    b.Property<int?>("unitNameId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.HasIndex("unitNameId");

                    b.ToTable("UnitPrices");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.UserRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool?>("category")
                        .HasColumnType("bit");

                    b.Property<bool?>("createInvoice")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("dateCreated")
                        .HasColumnType("date");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("enterpriseInfor")
                        .HasColumnType("bit");

                    b.Property<bool?>("invoiceManagement")
                        .HasColumnType("bit");

                    b.Property<bool?>("report")
                        .HasColumnType("bit");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("setting")
                        .HasColumnType("bit");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.Property<bool?>("userManagement")
                        .HasColumnType("bit");

                    b.Property<bool?>("warehouseManagement")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Account", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.Employee", "Employee")
                        .WithMany("Accounts")
                        .HasForeignKey("employeeId");

                    b.HasOne("DrugstoreManagement.Data.Entities.UserRole", "UserRole")
                        .WithMany("Accounts")
                        .HasForeignKey("userRoleid");

                    b.Navigation("Employee");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportBill", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.Account", "Account")
                        .WithMany("ImportBills")
                        .HasForeignKey("creator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugstoreManagement.Data.Entities.Supplier", "Supplier")
                        .WithMany("ImportBills")
                        .HasForeignKey("supplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportBillDetail", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.ImportBill", "ImportBill")
                        .WithMany("ImportBillDetails")
                        .HasForeignKey("importBillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugstoreManagement.Data.Entities.Product", "Product")
                        .WithMany("ImportBillDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImportBill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportInventoryBill", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.Account", "Account")
                        .WithMany("ImportInventoryBills")
                        .HasForeignKey("creator")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportInventoryBillDetail", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.ImportInventoryBill", "ImportInventoryBill")
                        .WithMany("ImportInventoryBillDetails")
                        .HasForeignKey("ImportInventoryBillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugstoreManagement.Data.Entities.Product", "Product")
                        .WithMany("ImportInventoryBillDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImportInventoryBill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.PrescriptionDetail", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.Prescription", "Prescription")
                        .WithMany("PrescriptionDetails")
                        .HasForeignKey("prescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugstoreManagement.Data.Entities.Product", "Product")
                        .WithMany("PrescriptionDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrugstoreManagement.Data.Entities.UnitName", "UnitName")
                        .WithMany("PrescriptionDetails")
                        .HasForeignKey("unitNameId");

                    b.Navigation("Prescription");

                    b.Navigation("Product");

                    b.Navigation("UnitName");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Product", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("idCategory");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Supplier", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.SupplierRole", "SupplierRole")
                        .WithMany("Suppliers")
                        .HasForeignKey("SupplierRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SupplierRole");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.UnitPrice", b =>
                {
                    b.HasOne("DrugstoreManagement.Data.Entities.Product", "Product")
                        .WithMany("UnitPrices")
                        .HasForeignKey("productId");

                    b.HasOne("DrugstoreManagement.Data.Entities.UnitName", "UnitName")
                        .WithMany("UnitPrices")
                        .HasForeignKey("unitNameId");

                    b.Navigation("Product");

                    b.Navigation("UnitName");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Account", b =>
                {
                    b.Navigation("ImportBills");

                    b.Navigation("ImportInventoryBills");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Employee", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportBill", b =>
                {
                    b.Navigation("ImportBillDetails");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ImportInventoryBill", b =>
                {
                    b.Navigation("ImportInventoryBillDetails");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Prescription", b =>
                {
                    b.Navigation("PrescriptionDetails");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Product", b =>
                {
                    b.Navigation("ImportBillDetails");

                    b.Navigation("ImportInventoryBillDetails");

                    b.Navigation("PrescriptionDetails");

                    b.Navigation("UnitPrices");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.Supplier", b =>
                {
                    b.Navigation("ImportBills");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.SupplierRole", b =>
                {
                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.UnitName", b =>
                {
                    b.Navigation("PrescriptionDetails");

                    b.Navigation("UnitPrices");
                });

            modelBuilder.Entity("DrugstoreManagement.Data.Entities.UserRole", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
