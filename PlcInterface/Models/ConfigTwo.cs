﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models
{
    public class ConfigTwo
    {
        public int Id { get; set; }
        public string BrokerId { get; set; }
        public string MachineId { get; set; }
        public int State { get; set; }
        public decimal Fault { get; set; }
        public int ProductionCount { get; set; }
        public decimal ActualSpeed { get; set; }
        public decimal MixVolume { get; set; }
        public int ProgramSelection { get; set; }
        public int MachineMode { get; set; }
        public decimal CO2 { get; set; }
        public int ProdTime { get; set; }
        public DateTime TimeStamp { get; set; } 
    }
}
