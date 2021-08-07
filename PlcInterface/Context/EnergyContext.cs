using Microsoft.EntityFrameworkCore;
using PlcInterface.Models.EnergyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Context
{
    public class EnergyContext : DbContext
    {
        public DbSet<IotTransaction> IotTransactions { get; set; }
        public EnergyContext(DbContextOptions<EnergyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
