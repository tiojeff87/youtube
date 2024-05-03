using Microsoft.EntityFrameworkCore;
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
                    Youtuber_Trophy = 100000,
                    YoutuberId = 1,
                    SpecialDetails = "Some special details for this record"
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 1000000,
                    YoutuberId = 1,
                    SpecialDetails = "Some special details for this record"
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 100001,
                    YoutuberId = 2,
                    SpecialDetails = "Some special details for this record"
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 100002,
                    YoutuberId = 3,
                    SpecialDetails = "Some special details for this record"
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 100005,
                    YoutuberId = 3,
                    SpecialDetails = "Some special details for this record"
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 10000000,
                    YoutuberId = 3,
                    SpecialDetails = "Some special details for this record"
                },
                new YoutuberRecords
                {
                    Youtuber_Trophy = 50000000,
                    YoutuberId = 3,
                    SpecialDetails = "Some special details for this record"
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Habilitar o Sensitive Data Logging
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
