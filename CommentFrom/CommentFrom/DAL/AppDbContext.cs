using CommentFrom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentFrom.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {}
        public DbSet<Service> Services{ get; set; }
        public DbSet<Advantage> Advantages{ get; set; }
        public DbSet<ServiceCategory> ServiceCategories{ get; set; }
        public DbSet<Employee> Employees{ get; set; }
    }
}
