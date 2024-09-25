﻿// <auto-generated />
using System;
using EFHomeTaskLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFHomeTaskLibrary.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20240804110839_DataBaseNameMisspellFix")]
    partial class DataBaseNameMisspellFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFHomeTaskLibrary.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreateDate")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateOnly>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EFHomeTaskLibrary.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Height")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<decimal>("Length")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<decimal>("Width")
                        .HasColumnType("numeric(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EFHomeTaskLibrary.Order", b =>
                {
                    b.HasOne("EFHomeTaskLibrary.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
