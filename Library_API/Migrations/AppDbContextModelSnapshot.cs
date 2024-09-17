﻿// <auto-generated />
using System;
using Library_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library_API.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Author of Book",
                            Genre = "Genre of Book",
                            IsAvailable = true,
                            Published = new DateTime(2024, 9, 13, 20, 39, 52, 834, DateTimeKind.Local).AddTicks(9306),
                            Title = "Titel of Book"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Book Author",
                            Genre = "Book Genre",
                            IsAvailable = true,
                            Published = new DateTime(2024, 9, 13, 20, 39, 52, 834, DateTimeKind.Local).AddTicks(9348),
                            Title = "Book Title"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "The Author",
                            Genre = "The Genre",
                            IsAvailable = false,
                            Published = new DateTime(2024, 9, 13, 20, 39, 52, 834, DateTimeKind.Local).AddTicks(9351),
                            Title = "The Titel"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
