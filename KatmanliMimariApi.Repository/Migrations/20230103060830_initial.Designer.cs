﻿// <auto-generated />
using System;
using KatmanliMimariApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KatmanliMimariApi.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230103060830_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KatmanlıMimariApi.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalem"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Defter"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kitap"
                        });
                });

            modelBuilder.Entity("KatmanlıMimariApi.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 1, 3, 9, 8, 30, 697, DateTimeKind.Local).AddTicks(1355),
                            Name = "Kalem1",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 1, 3, 9, 8, 30, 697, DateTimeKind.Local).AddTicks(1368),
                            Name = "Kitap1",
                            Price = 600m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2023, 1, 3, 9, 8, 30, 697, DateTimeKind.Local).AddTicks(1370),
                            Name = "Defter",
                            Price = 60m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 1, 3, 9, 8, 30, 697, DateTimeKind.Local).AddTicks(1409),
                            Name = "Kitap2",
                            Price = 100m,
                            Stock = 20
                        });
                });

            modelBuilder.Entity("KatmanlıMimariApi.Core.Models.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Kırmızı",
                            Height = 100,
                            ProductId = 1,
                            Width = 100
                        },
                        new
                        {
                            Id = 2,
                            Color = "Kırmızı",
                            Height = 100,
                            ProductId = 2,
                            Width = 100
                        });
                });

            modelBuilder.Entity("KatmanlıMimariApi.Core.Models.Product", b =>
                {
                    b.HasOne("KatmanlıMimariApi.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KatmanlıMimariApi.Core.Models.ProductFeature", b =>
                {
                    b.HasOne("KatmanlıMimariApi.Core.Models.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("KatmanlıMimariApi.Core.Models.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KatmanlıMimariApi.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("KatmanlıMimariApi.Core.Models.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}