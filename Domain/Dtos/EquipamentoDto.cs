namespace Aplicacao.Dtos
{
    public record EquipamentoDto
    {
        public int CodigoTipoEquipamento { get; init; }
        public string TipoEquipamento { get; init; }
        public int CodigoFabricante { get; init; }
        public string? NomeFabricante { get; init; }
        public int CodigoCategoria { get; init; }
        public string? NomeCategoria { get; init; }
    }
}
