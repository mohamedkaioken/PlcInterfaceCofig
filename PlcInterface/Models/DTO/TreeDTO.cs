using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class TreeDTO
    {
        public string name { get; set; }
        public string img { get; set; }
        public int id { get; set; }
        public string code { get; set; }
        public string signalCode { get; set; }
        public string energyCode { get; set; }
        public string plcCode { get; set; }
        public List<TreeDTO> children { get; set; } = new List<TreeDTO>();
    }
}
