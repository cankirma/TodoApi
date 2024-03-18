﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240317175909_migration_5")]
    partial class migration_5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Todos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1e1b5dc-fc19-4d81-b556-1946eb707861"),
                            Content = "This is the first todo",
                            CreateTime = new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5401),
                            Title = "First Todo",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0a91e99d-fa6c-43ee-98f3-6534ffd24ecf"),
                            Content = "This is the second todo",
                            CreateTime = new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5402),
                            Title = "Second Todo",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4ff9a10a-a601-4a6b-82c2-c5a30982c142"),
                            CreateTime = new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5537),
                            Email = "user@example.com",
                            FirstName = "Can",
                            LastName = "Candan",
                            Password = "D0B3749570B6AA9155E3CAF5E42D9AEFE826600AF86A80EE4051CE6F76FA5D0D:2A59480760E144B6C0BC4954D3C2B37B:50000:SHA256",
                            UpdatedDate = new DateTime(2024, 3, 17, 17, 59, 9, 536, DateTimeKind.Utc).AddTicks(5538)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}