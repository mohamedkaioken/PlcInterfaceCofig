using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class MixerConsumption
    {
        public int Id { get; set; }
        public int LineId { get; set; }
        public int ProgramSelect { get; set; }
        public string ProgramName { get; set; }
        public decimal WaterConsumption { get; set; }
        public decimal SyrupConsumption { get; set; }
        public decimal CO2Volume { get; set; }
        public decimal VolumeOfBottle { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
