using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.EnergyModels
{
    public class AggregatedIotDay
    {
        public int Id { get; set; }
        public string SourceId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgV1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgV2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgV3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgI1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgI2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgI3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPF1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPF2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPF3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPapp1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPapp2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPapp3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPact1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPact2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPact3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPreact1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPreact2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgPreact3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal SumEnergy1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal SumEnergy2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal SumEnergy3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgTHDv1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgTHDv2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgTHDv3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgTHDi1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgTHDi2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal AvgTHDi3 { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
