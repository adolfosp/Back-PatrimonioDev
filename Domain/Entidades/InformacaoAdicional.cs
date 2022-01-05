using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class InformacaoAdicional
    {
        [Key]
        public int CodigoInformacao { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorPago { get; set; }
        [Required]
        public DateTime DataCompra { get; set; }
        public DateTime? DataExpericaoGarantia { get; set; }
        public string? Antivirus { get; set; }
        public string? VersaoWindows { get; set; }

        [Required(ErrorMessage = "É necessário informar o patrimonio")]
        public int CodigoPatrimonio { get; set; }
        [ForeignKey("CodigoPatrimonio")]
        public Patrimonio Patrimonio { get; set; }
    }
}
