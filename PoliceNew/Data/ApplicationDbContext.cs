using Microsoft.EntityFrameworkCore;
using PoliceNew.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliceNew.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public DbSet<Department> Departments { get; set; }
        public DbSet<Officers> Officers { get; set; }
    }
}
