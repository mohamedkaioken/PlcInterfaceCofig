using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class MaterialNameDTO
    {
        public string name { get; set; }
        public List<MaterialNameDTO> children { get; set; } = new List<MaterialNameDTO>();
    }
}
