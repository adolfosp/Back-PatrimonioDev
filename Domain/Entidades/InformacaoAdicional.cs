using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class InformacaoAdicional
    {
        [Key]
        public int CodigoInformacao { get; set; }

        [Column(TypeName = "decimal(10, 2)"), Required]
        public decimal ValorPago { get; set; }

        [Required]
        public string DataCompra { get; set; }
        public string? DataExpiracaoGarantia { get; set; }
        public string? Antivirus { get; set; }
        public string? VersaoWindows { get; set; }

        [Required]
        public int CodigoPatrimonio { get; set; }
        [ForeignKey("CodigoPatrimonio")]
        public Patrimonio Patrimonio { get; set; }
    }
}
