using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class LineDetailsDTO
    {
        public int LineId { get; set; }
        public decimal EnergyConsumption { get; set; }
        public decimal EnergyConsumptionUseIndex { get; set; }
        public decimal PF { get; set; }
        public decimal CO2 { get; set; }
        public decimal SC { get; set; }
        public decimal WC { get; set; }
        public decimal PalletConsumption { get; set; }
        public decimal PackConsumption { get; set; }
        public decimal BottleConsumption { get; set; }
        public decimal ProductionTime { get; set; }
        public decimal Speed { get; set; }
        public decimal Quality { get; set; }
        public decimal Performance { get; set; }
        public decimal Avalability { get; set; }
        public decimal OEE { get; set; }
        public decimal ProductionHours { get; set; }
        public decimal FaultPerc { get; set; }
        public decimal Fault { get; set; }

        public int Rinse { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
