using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class OeeDay
    {
        public int Id { get; set; }
        public string MachineId { get; set; }
        public decimal OEE { get; set; }
        public decimal Availability { get; set; }
        public decimal Performance { get; set; }
        public decimal Quality { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
