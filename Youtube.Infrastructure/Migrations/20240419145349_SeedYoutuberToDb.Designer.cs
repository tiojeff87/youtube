﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Youtube.Infrastructure.Data;

#nullable disable

namespace Youtube.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240419145349_SeedYoutuberToDb")]
    partial class SeedYoutuberToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Youtube.Domain.Entities.Youtuber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Joined")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subscribers")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("videos")
                        .HasColumnType("int");

                    b.Property<int>("views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Youtubers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Joined = new DateTime(2024, 4, 19, 15, 53, 49, 399, DateTimeKind.Local).AddTicks(8347),
                            Name = "Wuant",
                            Subscribers = 3690000,
                            country = "Portugal",
                            videos = 1596,
                            views = 1342325614
                        },
                        new
                        {
                            Id = 2,
                            Joined = new DateTime(2024, 4, 19, 15, 53, 49, 399, DateTimeKind.Local).AddTicks(8406),
                            Name = "Toshiruz",
                            Subscribers = 616000,
                            country = "Brazil",
                            videos = 1482,
                            views = 124672906
                        },
                        new
                        {
                            Id = 3,
                            Joined = new DateTime(2024, 4, 19, 15, 53, 49, 399, DateTimeKind.Local).AddTicks(8409),
                            Name = "Wuant",
                            Subscribers = 111000000,
                            country = "Sweden",
                            videos = 4760,
                            views = 292766664
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
