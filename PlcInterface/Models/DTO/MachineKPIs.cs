using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class MachineKPIs
    {
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public string MachineType { get; set; }
        public decimal Availability { get; set; }
        public decimal Performance { get; set; }
        public decimal Quality { get; set; }
        public decimal OEE { get; set; }
        public decimal TEEP { get; set; }
        public decimal Utiliztion { get; set; }
        public decimal MTBF { get; set; }
        public decimal UpTime { get; set; }
        public decimal ProductionHours { get; set; }
        public decimal Production_OutPut { get; set; }
        public decimal Max_Production_Capacity { get; set; }
        public decimal Throughput { get; set; }
        public decimal Yield { get; set; }
        public decimal TotalDownTime { get; set; }
        public decimal ChangeOverTime { get; set; }
        public decimal CycleTime { get; set; }
        public decimal OverAllOEE { get; set; }
        public decimal OverAllMTBF { get; set; }
        public decimal OverAllUpTime { get; set; }
        public List<StateTime> StateTimes { get; set; } = new List<StateTime>();
        public DateTime from { get; set; }
        public DateTime to { get; set; }

    }
}
