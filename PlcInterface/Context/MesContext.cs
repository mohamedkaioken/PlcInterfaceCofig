using Microsoft.EntityFrameworkCore;
using PlcInterface.Models.CocaMesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Context
{
    public class MesContext : DbContext
    {
        public DbSet<Load> Loads { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<ProductionLine> ProductionLines { get; set; }
        public DbSet<MachineParameter> MachineParameters { get; set; }
        public DbSet<Compressor> Compressors { get; set; }
        public DbSet<Boiler> Boilers { get; set; }
        public DbSet<WaterChemicalTreatment> WaterChemicalTreatments { get; set; }
        public DbSet<WaterPump> WaterPumps { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public MesContext(DbContextOptions<MesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
