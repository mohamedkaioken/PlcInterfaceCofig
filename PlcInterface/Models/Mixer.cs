using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models
{
    public class Mixer
    {
        public int Id { get; set; }
        public string Factory { get; set; }
        public int Line { get; set; }
        public string MachineId { get; set; }
        public int State { get; set; }
        public int Fault { get; set; }
        public decimal Product_Consumption { get; set; }
        public decimal Co2_Consumption { get; set; }
        public decimal Water_Consumption { get; set; }
        public decimal Syrup_Consumption { get; set; }
        public int Production_Hours { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

