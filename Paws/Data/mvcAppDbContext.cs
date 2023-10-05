using Microsoft.EntityFrameworkCore;
using Paws.Models;
using System.Collections.Generic;

namespace Paws.Data
{
    public class mvcAppDbContext : DbContext
    {
        public mvcAppDbContext(DbContextOptions<mvcAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pets> Pets { get; set; }
    }
}

