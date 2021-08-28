using Microsoft.EntityFrameworkCore;
using PlcInterface.Models;
using PlcInterface.Models.CocaMesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ConfigOne> ConfigOne { get; set; }
        public DbSet<ConfigTwo> ConfigTwo { get; set; }
        public DbSet<ConfigThree> ConfigThree { get; set; }

        public DbSet<Filler> Fillers { get; set; }
        public DbSet<Palletizer> Palletizers { get; set; }
        public DbSet<Blow_Moulder> Blow_Moulders { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<DPalletizer> DPalletizers { get; set; }
        public DbSet<Mixer> Mixers { get; set; }
        public DbSet<Cartonizer_Shrink> Cartonizers_Shrinks { get; set; }
        public DbSet<MixerConsumption> MixerConsumptions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
