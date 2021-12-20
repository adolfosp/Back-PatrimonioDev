using System;

namespace Aplicacao.Dtos
{
    public class InformacaoAdicionalDto
    {
     
        public decimal ValorPago { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime? DataExpericaoGarantia { get; set; }
        public string? Antivirus { get; set; }
        public string? VersaoWindows { get; set; }
    }
}
