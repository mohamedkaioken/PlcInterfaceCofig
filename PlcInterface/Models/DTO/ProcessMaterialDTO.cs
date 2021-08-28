using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class ProcessMaterialDTO
    {
        public string name { get; set; }
        public List<MaterialNameDTO> children { get; set; } = new List<MaterialNameDTO>();
    }
}
