namespace Aplicacao.Dtos
{
    public record InformacaoAdicionalDto
    {
        public int CodigoInformacaoAdicional { get; init; }
        public decimal ValorPago { get; init; }
        public string? DataCompra { get; init; }
        public string? DataExpiracaoGarantia { get; init; }
        public string? Antivirus { get; init; }
        public string? VersaoWindows { get; init; }

    }
}
