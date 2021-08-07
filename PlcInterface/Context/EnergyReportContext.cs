using Microsoft.EntityFrameworkCore;
using PlcInterface.Models.EnergyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Context
{
    public class EnergyReportContext : DbContext
    {
        public DbSet<AggregatedIotDay> AggregatedIotDays { get; set; }
        public DbSet<AggregatedIotMin> AggregatedIotMins { get; set; }
        public EnergyReportContext(DbContextOptions<EnergyReportContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
