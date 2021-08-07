using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class Load
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? SignalCode { get; set; }
        public string? EnergyCode { get; set; }
        public string? PlcCode { get; set; }
        public int? FactoryId { get; set; }
        public int? ProductionLineId { get; set; }
        public int? UtilityId { get; set; }
        public Factory Factory { get; set; }
        public ProductionLine ProductionLine { get; set; }
        public Utility Utility { get; set; }
    }
}
