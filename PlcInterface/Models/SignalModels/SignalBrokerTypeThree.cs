using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.SignalModels
{
    public class SignalBrokerTypeThree
    {
        public int Id { get; set; }
        public string BrokerId { get; set; }
        public int State { get; set; }
        public int Fault { get; set; }
        public int In_Count { get; set; }
        public int Out_Count { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
