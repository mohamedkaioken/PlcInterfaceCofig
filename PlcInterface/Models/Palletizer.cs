using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models
{
    public class Palletizer
    {
        public int Id { get; set; }
        public string Factory { get; set; }
        public int Line { get; set; }
        public string MachineId { get; set; }
        public int State { get; set; }
        public int Fault { get; set; }
        public int Packet_No { get; set; }
        public int Pallet_No { get; set; }
        public int Production_Hours { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
