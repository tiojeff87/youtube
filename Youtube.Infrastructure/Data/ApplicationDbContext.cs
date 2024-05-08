using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.Metrics;
using Youtube.Domain.Entities;

namespace Youtube.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
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
                Joined = new DateTime(2012, 1, 11),
                country = "Portugal",
            },
            new Youtuber
            {
                Id = 2,
                Name = "Toshiruz",
                Subscribers = 616000,
                videos = 1482,
                views = 124672906,
                Joined = new DateTime(2014, 7, 25),
                country = "Brazil",
            },
            new Youtuber
            {
                Id = 3,
                Name = "Wuant",
                Subscribers = 111000000,
                videos = 4760,
                views = 292766664,
                Joined = new DateTime(2010, 4, 29),
                country = "Sweden",
            });

            modelBuilder.Entity<YoutuberRecords>().HasData(
                new YoutuberRecords
                {
                    Votos = 100001,
                    YoutuberId = 1,
                    Youtuber_Trophy = "silver"
                },
                new YoutuberRecords
                {
                    Votos = 1000001,
                    YoutuberId = 1,
                    Youtuber_Trophy = "gold"
                },
                new YoutuberRecords
                {
                    Votos = 100002,
                    YoutuberId = 2,
                    Youtuber_Trophy = "silver"
                },
                new YoutuberRecords
                {
                    Votos = 100003,
                    YoutuberId = 3,
                    Youtuber_Trophy = "silver"
                },
                new YoutuberRecords
                {
                    Votos = 10000003,
                    YoutuberId = 3,
                    Youtuber_Trophy = "gold"
                },
                new YoutuberRecords
                {
                    Votos = 100000003,
                    YoutuberId = 3,
                    Youtuber_Trophy = "diamond"
                },
                new YoutuberRecords
                {
                    Votos = 50000003,
                    YoutuberId = 3,
                    Youtuber_Trophy = "ruby"
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