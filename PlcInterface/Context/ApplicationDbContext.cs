using Microsoft.EntityFrameworkCore;
using PlcInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ConfigOne> ConfigsOne { get; set; }
        public DbSet<ConfigTwo> ConfigsTwo { get; set; }
        public DbSet<ConfigThree> ConfigsThree { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
