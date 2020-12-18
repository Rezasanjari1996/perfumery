using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Perfumery.Models
{
    public class PerfumeryConext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=PerfumeryDb;Trusted_Connection=True;");
        }


       public DbSet<person> person { get; set; }
        public DbSet<Perfume> Perfumes { get; set; }
    }
}
