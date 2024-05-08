﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Youtube.Infrastructure.Data;

#nullable disable

namespace Youtube.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .IsRequired()
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
                            Joined = new DateTime(2012, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Wuant",
                            Subscribers = 3690000,
                            country = "Portugal",
                            videos = 1596,
                            views = 1342325614
                        },
                        new
                        {
                            Id = 2,
                            Joined = new DateTime(2014, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Toshiruz",
                            Subscribers = 616000,
                            country = "Brazil",
                            videos = 1482,
                            views = 124672906
                        },
                        new
                        {
                            Id = 3,
                            Joined = new DateTime(2010, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Wuant",
                            Subscribers = 111000000,
                            country = "Sweden",
                            videos = 4760,
                            views = 292766664
                        });
                });

            modelBuilder.Entity("Youtube.Domain.Entities.YoutuberRecords", b =>
                {
                    b.Property<int>("Votos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Votos"));

                    b.Property<int>("YoutuberId")
                        .HasColumnType("int");

                    b.Property<string>("Youtuber_Trophy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Votos");

                    b.HasIndex("YoutuberId");

                    b.ToTable("YoutuberRecords");

                    b.HasData(
                        new
                        {
                            Votos = 100001,
                            YoutuberId = 1,
                            Youtuber_Trophy = "silver"
                        },
                        new
                        {
                            Votos = 1000001,
                            YoutuberId = 1,
                            Youtuber_Trophy = "gold"
                        },
                        new
                        {
                            Votos = 100002,
                            YoutuberId = 2,
                            Youtuber_Trophy = "silver"
                        },
                        new
                        {
                            Votos = 100003,
                            YoutuberId = 3,
                            Youtuber_Trophy = "silver"
                        },
                        new
                        {
                            Votos = 10000003,
                            YoutuberId = 3,
                            Youtuber_Trophy = "gold"
                        },
                        new
                        {
                            Votos = 100000003,
                            YoutuberId = 3,
                            Youtuber_Trophy = "diamond"
                        },
                        new
                        {
                            Votos = 50000003,
                            YoutuberId = 3,
                            Youtuber_Trophy = "ruby"
                        });
                });

            modelBuilder.Entity("Youtube.Domain.Entities.YoutuberRecords", b =>
                {
                    b.HasOne("Youtube.Domain.Entities.Youtuber", "Youtuber")
                        .WithMany()
                        .HasForeignKey("YoutuberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Youtuber");
                });
#pragma warning restore 612, 618
        }
    }
}
