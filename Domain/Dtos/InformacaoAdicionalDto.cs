using System;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class InformacaoAdicionalDto
    {
        [Display(Name = "Valor pago")]
        [Required(ErrorMessage = "É necessário informar o {0}.")]
        public decimal ValorPago { get; set; }
        [Required(ErrorMessage ="É necessário informar a data de compra.")]
        public DateTime DataCompra { get; set; }
        public DateTime? DataExpericaoGarantia { get; set; }
        public string? Antivirus { get; set; }
        public string? VersaoWindows { get; set; }

        [Required(ErrorMessage = "É necessário o código do patrimônio.")]
        public int CodigoPatrimonio { get; set; }

    }
}
