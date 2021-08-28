using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.DTO
{
    public class RouteRootDTO
    {
        public string name { get; set; }
        public List<ProcessTreeDTO> children { get; set; } = new List<ProcessTreeDTO>();
    }
}
