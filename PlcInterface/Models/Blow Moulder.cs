using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models
{
    public class Blow_Moulder
    {
        public int Id { get; set; }
        public string Factory { get; set; }
        public int Line { get; set; }
        public string MachineId { get; set; }
        public int State { get; set; }
        public int Fault { get; set; }
        public decimal Speed { get; set; }
        public int Count_In { get; set; }
        public int Count_Out { get; set; }
        public decimal Temperature { get; set; }
        public decimal Pressure { get; set; }
        public int Production_Hours { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
