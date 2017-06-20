using Microsoft.EntityFrameworkCore;
using SimpleRepository.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRepository.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
