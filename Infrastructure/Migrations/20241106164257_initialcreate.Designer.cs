﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241106164257_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Aggregates.ProductAggregate.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.ProductAggregate.Entities.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("product_details", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccountCredentials", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserAccountRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("users_credentials", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccountInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users_info", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccountSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("EmailNotifications")
                        .HasColumnType("bit");

                    b.Property<bool>("SMSNotifications")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("users_settings", (string)null);
                });

            modelBuilder.Entity("Domain.Aggregates.ProductAggregate.Entities.ProductDetail", b =>
                {
                    b.HasOne("Domain.Aggregates.ProductAggregate.Entities.Product", null)
                        .WithOne("ProductDetail")
                        .HasForeignKey("Domain.Aggregates.ProductAggregate.Entities.ProductDetail", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccountCredentials", b =>
                {
                    b.HasOne("Domain.Aggregates.UserAggregate.Entities.UserAccount", null)
                        .WithOne("UserAccountCredentials")
                        .HasForeignKey("Domain.Aggregates.UserAggregate.Entities.UserAccountCredentials", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccountInfo", b =>
                {
                    b.HasOne("Domain.Aggregates.UserAggregate.Entities.UserAccount", null)
                        .WithOne("UserAccountInfo")
                        .HasForeignKey("Domain.Aggregates.UserAggregate.Entities.UserAccountInfo", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccountSettings", b =>
                {
                    b.HasOne("Domain.Aggregates.UserAggregate.Entities.UserAccount", null)
                        .WithOne("UserAccountSettings")
                        .HasForeignKey("Domain.Aggregates.UserAggregate.Entities.UserAccountSettings", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Aggregates.ProductAggregate.Entities.Product", b =>
                {
                    b.Navigation("ProductDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Aggregates.UserAggregate.Entities.UserAccount", b =>
                {
                    b.Navigation("UserAccountCredentials")
                        .IsRequired();

                    b.Navigation("UserAccountInfo")
                        .IsRequired();

                    b.Navigation("UserAccountSettings")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}