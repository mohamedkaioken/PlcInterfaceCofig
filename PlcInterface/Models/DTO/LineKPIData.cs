using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class LineKPIData
    {
        public string MachineName { get; set; }
        public decimal CycleTime { get; set; }
        public decimal Throughput { get; set; }
        public decimal ProductionOutPut { get; set; }
        public decimal OEE { get; set; }
        public decimal Availability { get; set; }
        public decimal Performance { get; set; }
        public decimal Quality { get; set; }
        public decimal MTBF { get; set; }
        public decimal Uptime { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
