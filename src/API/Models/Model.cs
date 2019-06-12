using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetAPI.Repository;

namespace dotnetAPI.Models
{
    public class Model
    {
    }


    public class SitDbContext : DbContext
    {
        public SitDbContext(DbContextOptions<SitDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Api>()
                .HasAlternateKey(a => new { a.Url});
        }

        public DbSet<Api> API { get; set; }
        public DbSet<NinetyDayAverage> NinetyDayAverage { get; set; }
        public DbSet<TestResults> TestResults { get; set; }
        public DbSet<Error> Error { get; set; }


    }
}
