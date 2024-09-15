﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiverBooks.Books;

#nullable disable

namespace RiverBooks.Books.Persistence.Migrations
{
    [DbContext(typeof(BookDbContext))]
    partial class BookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Books")
                .HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("RiverBooks.Books.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books", "Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a4d6350f-0c5b-49e6-9c42-c1aa96396db9"),
                            Author = "John Doe",
                            Price = 10.99m,
                            Title = "Book 1"
                        },
                        new
                        {
                            Id = new Guid("c1bbd273-1849-4f6e-91da-0ecc17eb3eac"),
                            Author = "John Doe",
                            Price = 11.99m,
                            Title = "Book 2"
                        },
                        new
                        {
                            Id = new Guid("9aaa9ee0-ca80-4f86-8f17-7494b0d95056"),
                            Author = "John Doe",
                            Price = 12.99m,
                            Title = "Book 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
