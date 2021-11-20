using LightsOut.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightsOut.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GameSettings> GameSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameSettings>().HasData(
                new GameSettings { Id = 1, Name = "5 x 5", BoardSize = 5 },
                new GameSettings { Id = 2, Name = "8 x 8", BoardSize = 8 },
                new GameSettings { Id = 3, Name = "10 x 10", BoardSize = 10 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
