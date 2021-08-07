using Microsoft.EntityFrameworkCore;
using PlcInterface.Models.SignalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Context
{
    public class SignalContext : DbContext
    {
        public DbSet<SignalBroker> SignalBroker { get; set; }
        public SignalContext(DbContextOptions<SignalContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
