using System;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class InformacaoAdicionalDto
    {
        public int CodigoInformacaoAdicional { get; set; }
        public decimal ValorPago { get; set; }
        public string? DataCompra { get; set; }
        public string? DataExpiracaoGarantia { get; set; }
        public string? Antivirus { get; set; }
        public string? VersaoWindows { get; set; }

    }
}
