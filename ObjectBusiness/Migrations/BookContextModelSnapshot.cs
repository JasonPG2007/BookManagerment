﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObjectBusiness;

#nullable disable

namespace ObjectBusiness.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ObjectBusiness.AccessLog", b =>
                {
                    b.Property<int>("AccessLogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAccess")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitCount")
                        .HasColumnType("int");

                    b.HasKey("AccessLogId");

                    b.ToTable("AccessLog");
                });

            modelBuilder.Entity("ObjectBusiness.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Point")
                        .HasColumnType("real");

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
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "Admin@123.cntt",
                            Point = 0f,
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

            modelBuilder.Entity("ObjectBusiness.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateComment")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("Interact")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("EventId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ObjectBusiness.Decentralization", b =>
                {
                    b.Property<int>("DecentralizationId")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDecentralization")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("DecentralizationId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Decentralizations");

                    b.HasData(
                        new
                        {
                            DecentralizationId = 996554186,
                            AccountId = 92687906,
                            DateDecentralization = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("ObjectBusiness.DisLikeComment", b =>
                {
                    b.Property<int>("DisLikeId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDisLike")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("DisLikeId");

                    b.HasIndex("CommentId");

                    b.ToTable("DisLikeComments");
                });

            modelBuilder.Entity("ObjectBusiness.Event", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfParticipants")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("AccountId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ObjectBusiness.EventCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryId");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("ObjectBusiness.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Evaluate")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("ObjectBusiness.LikeComment", b =>
                {
                    b.Property<int>("LikeId")
                        .HasColumnType("int");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateLike")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("LikeId");

                    b.HasIndex("CommentId");

                    b.ToTable("LikeComments");
                });

            modelBuilder.Entity("ObjectBusiness.RegisterJoinEvent", b =>
                {
                    b.Property<int>("RegisterId")
                        .HasColumnType("int");

                    b.HasKey("RegisterId");

                    b.ToTable("RegisterJoinEvents");
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

            modelBuilder.Entity("ObjectBusiness.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 26949135,
                            ServiceName = "Customer care"
                        });
                });

            modelBuilder.Entity("ObjectBusiness.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

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
                            Age = 17,
                            City = "Security",
                            DateRegister = new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "anonymous@gmail.com",
                            FullName = "Anonymous",
                            Gender = true,
                            PhoneNumber = "0911040107",
                            Picture = "avatar.jpg",
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

            modelBuilder.Entity("ObjectBusiness.Comment", b =>
                {
                    b.HasOne("ObjectBusiness.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
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

            modelBuilder.Entity("ObjectBusiness.DisLikeComment", b =>
                {
                    b.HasOne("ObjectBusiness.Comment", "Comment")
                        .WithMany("DisLikeComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("ObjectBusiness.Event", b =>
                {
                    b.HasOne("ObjectBusiness.Account", "Account")
                        .WithMany("Events")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBusiness.EventCategory", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ObjectBusiness.Feedback", b =>
                {
                    b.HasOne("ObjectBusiness.Account", "Account")
                        .WithMany("Feedbacks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ObjectBusiness.Service", "Service")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ObjectBusiness.LikeComment", b =>
                {
                    b.HasOne("ObjectBusiness.Comment", "Comment")
                        .WithMany("LikeComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("ObjectBusiness.Account", b =>
                {
                    b.Navigation("Decentralization");

                    b.Navigation("Events");

                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("ObjectBusiness.CategoryBook", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ObjectBusiness.Comment", b =>
                {
                    b.Navigation("DisLikeComments");

                    b.Navigation("LikeComments");
                });

            modelBuilder.Entity("ObjectBusiness.EventCategory", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ObjectBusiness.Role", b =>
                {
                    b.Navigation("Decentralizations");
                });

            modelBuilder.Entity("ObjectBusiness.Service", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("ObjectBusiness.User", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
