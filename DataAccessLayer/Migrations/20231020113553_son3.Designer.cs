﻿// <auto-generated />
using System;
using DataAccessLayer.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(FirstProgramContext))]
    [Migration("20231020113553_son3")]
    partial class son3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategorySupplier", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryID", "SupplierID");

                    b.HasIndex("SupplierID");

                    b.ToTable("CategorySupplier");
                });

            modelBuilder.Entity("Model.Entities.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Model.Entities.Company", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Model.Entities.Department", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Model.Entities.Invoice", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Model.Entities.Offer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("OfferAmount")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("OfferPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StatusID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SupplierID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ProductID");

                    b.HasIndex("StatusID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short?>("StockQuantity")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("InvoiceID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Model.Entities.Request", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DesiredQuantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("StatusID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("StatusID");

                    b.HasIndex("UserID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Model.Entities.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Model.Entities.Status", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Model.Entities.Supplier", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Model.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartmentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenExpireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CategorySupplier", b =>
                {
                    b.HasOne("Model.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.Entities.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Entities.Department", b =>
                {
                    b.HasOne("Model.Entities.Company", "Company")
                        .WithMany("Department")
                        .HasForeignKey("CompanyID");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Entities.Invoice", b =>
                {
                    b.HasOne("Model.Entities.Supplier", "Supplier")
                        .WithMany("Invoice")
                        .HasForeignKey("SupplierID");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Model.Entities.Offer", b =>
                {
                    b.HasOne("Model.Entities.Invoice", "Invoice")
                        .WithMany("Offer")
                        .HasForeignKey("InvoiceID");

                    b.HasOne("Model.Entities.Product", "Product")
                        .WithMany("Offer")
                        .HasForeignKey("ProductID");

                    b.HasOne("Model.Entities.Status", "Status")
                        .WithMany("Offer")
                        .HasForeignKey("StatusID");

                    b.HasOne("Model.Entities.Supplier", "Supplier")
                        .WithMany("Offer")
                        .HasForeignKey("SupplierID");

                    b.Navigation("Invoice");

                    b.Navigation("Product");

                    b.Navigation("Status");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.HasOne("Model.Entities.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryID");

                    b.HasOne("Model.Entities.Invoice", "Invoice")
                        .WithMany("Product")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Model.Entities.Request", b =>
                {
                    b.HasOne("Model.Entities.Category", "Category")
                        .WithMany("Request")
                        .HasForeignKey("CategoryID");

                    b.HasOne("Model.Entities.Status", "Status")
                        .WithMany("Request")
                        .HasForeignKey("StatusID");

                    b.HasOne("Model.Entities.User", "User")
                        .WithMany("Request")
                        .HasForeignKey("UserID");

                    b.Navigation("Category");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.User", b =>
                {
                    b.HasOne("Model.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");

                    b.HasOne("Model.Entities.Department", "Department")
                        .WithMany("User")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("Model.Entities.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Model.Entities.Category", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Model.Entities.Company", b =>
                {
                    b.Navigation("Department");
                });

            modelBuilder.Entity("Model.Entities.Department", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.Invoice", b =>
                {
                    b.Navigation("Offer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.Navigation("Offer");
                });

            modelBuilder.Entity("Model.Entities.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Entities.Status", b =>
                {
                    b.Navigation("Offer");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Model.Entities.Supplier", b =>
                {
                    b.Navigation("Invoice");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("Model.Entities.User", b =>
                {
                    b.Navigation("Request");
                });
#pragma warning restore 612, 618
        }
    }
}
