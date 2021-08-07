using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class MachineParameter
    {
        public int Id { get; set; }
        public string? MachineCode { get; set; }
        public string? ParameterName { get; set; }
    }
}
