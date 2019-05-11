using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

       //public DbSet<ApiList> ApiList { get; set; }
        public DbSet<Api> API { get; set; }

        public DbSet<Verb> Verb { get; set; }

    }
}
