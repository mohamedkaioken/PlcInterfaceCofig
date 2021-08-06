using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models
{
    public class Cartonizer_Shrink
    {
        public int Id { get; set; }
        public string Factory { get; set; }
        public int Line { get; set; }
        public string MachineId { get; set; }
        public int State { get; set; }
        public int Fault { get; set; }
        public decimal Speed { get; set; }
        public int Counts { get; set; }
        public int Hours { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
