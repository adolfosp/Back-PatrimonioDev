using Domain.Enums;

namespace Aplicacao.Dtos
{
    public class PatrimonioDto
    {
        public int CodigoPatrimonio { get; set; }
        public string? Modelo { get; set; }
        public string? ServiceTag { get; set; }
        public string? Armazenamento { get; set; }
        public string? Processador { get; set; }
        public string? PlacaDeVideo { get; set; }
        public string? MAC { get; set; }
        public string? MemoriaRAM { get; set; }
        public SituacaoEquipamento SituacaoEquipamento { get; set; }
        public int CodigoTipoEquipamento { get; set; }
        public string? TipoEquipamento { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoFuncionario { get; set; }
        public string? NomeFuncionario { get; set; }
    }
}

