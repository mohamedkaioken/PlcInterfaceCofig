using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlcInterface.Models.EnergyModels
{
    public class IotTransaction
    {
        public int Id { get; set; }
        public string SourceId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal V1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal V2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal V3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal I1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal I2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal I3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal PF1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal PF2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal PF3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Papp1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Papp2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Papp3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Pact1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Pact2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Pact3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Preact1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Preact2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Preact3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Energy1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Energy2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Energy3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal THDv1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal THDv2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal THDv3 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal THDi1 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal THDi2 { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal THDi3 { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
