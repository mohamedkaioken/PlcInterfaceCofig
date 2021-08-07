using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class PhaseValuesDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Phase1 { get; set; }
        public decimal Phase2 { get; set; }
        public decimal Phase3 { get; set; }
        public string Unit { get; set; }
        public int signal { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
