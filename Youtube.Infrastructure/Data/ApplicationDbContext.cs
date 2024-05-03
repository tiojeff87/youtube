﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.Metrics;
using Youtube.Domain.Entities;

namespace Youtube.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<Youtuber> Youtubers { get; set; }

        public DbSet<YoutuberRecords> YoutuberRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Youtuber>().HasData(
            new Youtuber
                {
                    Id = 1,
                    Name = "Wuant",
                    Subscribers = 3690000,
                    videos = 1596,
                    views = 1342325614,
                    Joined = DateTime.Now,
                    country = "Portugal",
                },
            new Youtuber
            {
                Id = 2,
                    Name = "Toshiruz",
                    Subscribers = 616000,
                    videos = 1482,
                    views = 124672906,
                    Joined = DateTime.Now,
                    country = "Brazil",
                },
            new Youtuber
            {
                Id = 3,
                    Name = "Wuant",
                    Subscribers = 111000000,
                    videos = 4760,
                    views = 292766664,
                    Joined = DateTime.Now,
                    country = "Sweden",
                });

            modelBuilder.Entity<YoutuberRecords>().HasData(
                new YoutuberRecords
                {
                    Youtuber_Trophy = 1,
                    YoutubeId = 1,
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 2,
                    YoutubeId = 1,
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 1,
                    YoutubeId = 2,
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 1,
                    YoutubeId = 3,
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 2,
                    YoutubeId = 3,
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 3,
                    YoutubeId = 3,
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 4,
                    YoutubeId = 3,
                });
        }
    }
}