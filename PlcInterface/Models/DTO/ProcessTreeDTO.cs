using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class ProcessTreeDTO
    {
        public string name { get; set; }
        public List<ProcessMaterialDTO> children { get; set; } = new List<ProcessMaterialDTO>();
    }
}
