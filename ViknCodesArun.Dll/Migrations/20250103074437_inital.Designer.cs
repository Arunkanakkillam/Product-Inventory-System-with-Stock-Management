﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViknCodesArun.Dll.ApplicationDbContext;

#nullable disable

namespace ViknCodesArun.Dll.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250103074437_inital")]
    partial class inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ViknCodesArun.Dll.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("CreatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HSNCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsFavourite")
                        .HasColumnType("bit");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalStock")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ProductCode")
                        .IsUnique()
                        .HasFilter("[ProductCode] IS NOT NULL");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ViknCodesArun.Dll.Models.SubVariants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Stock")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("VariantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VariantId");

                    b.ToTable("SubVariants");
                });

            modelBuilder.Entity("ViknCodesArun.Dll.Models.Variants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("ViknCodesArun.Dll.Models.SubVariants", b =>
                {
                    b.HasOne("ViknCodesArun.Dll.Models.Variants", "Variant")
                        .WithMany("SubVariants")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("ViknCodesArun.Dll.Models.Variants", b =>
                {
                    b.HasOne("ViknCodesArun.Dll.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ViknCodesArun.Dll.Models.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("ViknCodesArun.Dll.Models.Variants", b =>
                {
                    b.Navigation("SubVariants");
                });
#pragma warning restore 612, 618
        }
    }
}
