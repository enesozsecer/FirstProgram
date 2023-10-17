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
    [Migration("20231017124129_enson")]
    partial class enson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.Entities.Authenticate", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Authentications");
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

            modelBuilder.Entity("Model.Entities.Offer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("OfferAmount")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("OfferPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short?>("StockQuantity")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

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

            modelBuilder.Entity("Model.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthenticateID")
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

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenExpireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AuthenticateID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.Entities.Department", b =>
                {
                    b.HasOne("Model.Entities.Company", "Company")
                        .WithMany("Department")
                        .HasForeignKey("CompanyID");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Model.Entities.Offer", b =>
                {
                    b.HasOne("Model.Entities.Product", "Product")
                        .WithMany("Offer")
                        .HasForeignKey("ProductID");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.HasOne("Model.Entities.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
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
                    b.HasOne("Model.Entities.Authenticate", "Authenticate")
                        .WithMany("User")
                        .HasForeignKey("AuthenticateID");

                    b.HasOne("Model.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyID");

                    b.HasOne("Model.Entities.Department", "Department")
                        .WithMany("User")
                        .HasForeignKey("DepartmentID");

                    b.Navigation("Authenticate");

                    b.Navigation("Company");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Model.Entities.Authenticate", b =>
                {
                    b.Navigation("User");
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

            modelBuilder.Entity("Model.Entities.Product", b =>
                {
                    b.Navigation("Offer");
                });

            modelBuilder.Entity("Model.Entities.Status", b =>
                {
                    b.Navigation("Request");
                });

            modelBuilder.Entity("Model.Entities.User", b =>
                {
                    b.Navigation("Request");
                });
#pragma warning restore 612, 618
        }
    }
}
