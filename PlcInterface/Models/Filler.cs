using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models
{
    public class Filler
    {
        public int Id { get; set; }
        public string Factory { get; set; }
        public int Line { get; set; }
        public string MachineId { get; set; }
        public int State { get; set; }
        public int Fault { get; set; }
        public decimal Speed { get; set; }
        public int Count { get; set; }
        public decimal Mix_vol { get; set; }
        public int Mix_select { get; set; }
        public int Alarms { get; set; }
        public int Production_Hours { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
