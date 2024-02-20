﻿// <auto-generated />
using System;
using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(TheRealEstateDBContext))]
    [Migration("20240220104117_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusinessObject.BusinessObject.Auction", b =>
                {
                    b.Property<int>("AuctionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuctionID"), 1L, 1);

                    b.Property<bool>("AuctionType")
                        .HasColumnType("bit");

                    b.Property<int>("BidID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<double>("DepositeAmount")
                        .HasColumnType("float");

                    b.Property<double>("FeeAmount")
                        .HasColumnType("float");

                    b.Property<int>("RealEstateID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("AuctionID");

                    b.HasIndex("BidID");

                    b.HasIndex("RealEstateID");

                    b.ToTable("Auction", (string)null);
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.Bid", b =>
                {
                    b.Property<int>("BidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidID"), 1L, 1);

                    b.Property<double>("BidAmount")
                        .HasColumnType("float");

                    b.HasKey("BidID");

                    b.ToTable("Bid", (string)null);
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"), 1L, 1);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("RealEstateID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("RealEstateID");

                    b.HasIndex("UserID");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.RealEstate", b =>
                {
                    b.Property<int>("RealEstateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RealEstateID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Estimation")
                        .HasColumnType("float");

                    b.Property<string>("RealEstateAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealEstateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("RealEstateID");

                    b.HasIndex("UserID");

                    b.ToTable("RealEstate", (string)null);
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<int>("BidID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("BidID");

                    b.HasIndex("RoleID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.Auction", b =>
                {
                    b.HasOne("BusinessObject.BusinessObject.Bid", "Bid")
                        .WithMany("Auctions")
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BusinessObject.BusinessObject.RealEstate", "RealEstate")
                        .WithMany("Autions")
                        .HasForeignKey("RealEstateID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bid");

                    b.Navigation("RealEstate");
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.Comment", b =>
                {
                    b.HasOne("BusinessObject.BusinessObject.RealEstate", "RealEstate")
                        .WithMany("Comments")
                        .HasForeignKey("RealEstateID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BusinessObject.BusinessObject.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RealEstate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.RealEstate", b =>
                {
                    b.HasOne("BusinessObject.BusinessObject.User", "User")
                        .WithMany("RealEstates")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.User", b =>
                {
                    b.HasOne("BusinessObject.BusinessObject.Bid", "Bid")
                        .WithMany()
                        .HasForeignKey("BidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.BusinessObject.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bid");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.Bid", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.RealEstate", b =>
                {
                    b.Navigation("Autions");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObject.BusinessObject.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("RealEstates");
                });
#pragma warning restore 612, 618
        }
    }
}
