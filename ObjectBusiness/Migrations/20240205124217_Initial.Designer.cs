﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObjectBusiness;

#nullable disable

namespace ObjectBusiness.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20240205124217_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObjectBusiness.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 92687906,
                            Password = "Admin@123.cntt",
                            Star = 5,
                            UserId = 781404488,
                            UserName = "ADMIN"
                        });
                });

            modelBuilder.Entity("ObjectBusiness.Book", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Charges")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ObjectBusiness.CategoryBook", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Set")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("CategoryBooks");
                });

            modelBuilder.Entity("ObjectBusiness.Decentralization", b =>
                {
                    b.Property<int>("DecentralizationId")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("DecentralizationId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Decentralizations");
                });

            modelBuilder.Entity("ObjectBusiness.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Staff"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("ObjectBusiness.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 781404488,
                            Address = "Anonymous",
                            City = "Security",
                            Email = "anonymous@gmail.com",
                            FullName = "Anonymous",
                            Gender = true,
                            PhoneNumber = 911040107,
                            Region = "Security"
                        });
                });

            modelBuilder.Entity("ObjectBusiness.Account", b =>
                {
                    b.HasOne("ObjectBusiness.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("ObjectBusiness.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ObjectBusiness.Book", b =>
                {
                    b.HasOne("ObjectBusiness.CategoryBook", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ObjectBusiness.Decentralization", b =>
                {
                    b.HasOne("ObjectBusiness.Account", "Account")
                        .WithOne("Decentralization")
                        .HasForeignKey("ObjectBusiness.Decentralization", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBusiness.Role", "Role")
                        .WithMany("Decentralizations")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ObjectBusiness.Account", b =>
                {
                    b.Navigation("Decentralization");
                });

            modelBuilder.Entity("ObjectBusiness.CategoryBook", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ObjectBusiness.Role", b =>
                {
                    b.Navigation("Decentralizations");
                });

            modelBuilder.Entity("ObjectBusiness.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}