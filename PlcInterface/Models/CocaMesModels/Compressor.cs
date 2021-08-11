using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.CocaMesModels
{
    public class Compressor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int? FactoryId { get; set; }
        public Factory Factory { get; set; }
        public ICollection<Load> Loads { get; set; }
    }
}
