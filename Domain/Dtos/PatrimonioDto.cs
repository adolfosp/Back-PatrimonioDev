using Domain.Enums;

namespace Aplicacao.Dtos
{
    public record PatrimonioDto
    {
        public int CodigoPatrimonio { get; init; }
        public string? Modelo { get; init; }
        public string? ServiceTag { get; init; }
        public string? Armazenamento { get; init; }
        public string? Processador { get; init; }
        public string? PlacaDeVideo { get; init; }
        public string? MAC { get; init; }
        public string? MemoriaRAM { get; init; }
        public SituacaoEquipamento SituacaoEquipamento { get; init; }
        public int CodigoTipoEquipamento { get; init; }
        public string? TipoEquipamento { get; init; }
        public int CodigoUsuario { get; init; }
        public int CodigoFuncionario { get; init; }
        public string? NomeFuncionario { get; init; }
    }
}

