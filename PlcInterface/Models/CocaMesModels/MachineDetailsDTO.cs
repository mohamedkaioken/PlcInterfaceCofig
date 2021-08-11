using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class MachineDetailsDTO
    {
        public string MachineName { get; set; }
        public string MachineCode { get; set; }
        public string PlcType { get; set; }
        public decimal Avalability { get; set; }
        public decimal Performance { get; set; }
        public decimal Quality { get; set; }
        public decimal WC { get; set; }
        public decimal CO2 { get; set; }
        public decimal SC { get; set; }
        public decimal ProductionTime { get; set; }
        public decimal EnergyConsumption { get; set; }
        public decimal PalletCount { get; set; }
        public decimal PackCount { get; set; }
        public decimal BottleCount { get; set; }
        public decimal BottleCountIn { get; set; }
        public decimal BottleCountOut { get; set; }
        public int LineId { get; set; }
    }
}
