using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class Load
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? SignalCode { get; set; }
        public string? EnergyCode { get; set; }
        public string? PlcCode { get; set; }
        public int? FactoryId { get; set; }
        public int? ProductionLineId { get; set; }
        public int? UtilityId { get; set; }
        public Factory Factory { get; set; }
        public ProductionLine ProductionLine { get; set; }
        public Utility Utility { get; set; }
        public int? BoilerId { get; set; }
        public int? CompressorId { get; set; }
        public int? WaterPumpId { get; set; }
        public int? WaterChemicalTreatmentId { get; set; }
        public int? TankId { get; set; }
        public Boiler Boiler { get; set; }
        public Compressor Compressor { get; set; }
        public WaterPump WaterPump { get; set; }
        public WaterChemicalTreatment WaterChemicalTreatment { get; set; }
        public Tank Tank { get; set; }
    }
}
