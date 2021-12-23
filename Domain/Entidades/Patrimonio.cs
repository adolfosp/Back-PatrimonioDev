using Domain.Enums;

namespace Domain.Entidades
{
    public class Patrimonio
    {
        public int CodigoInformacao { get; set; }
        public string? Modelo { get; set; }
        public string? ServiceTag { get; set; }
        public string? Armazenamento { get; set; }
        public string? Processador { get; set; }
        public string? PlacaDeVideo { get; set; }
        public string? MAC { get; set; }
        public string? MemoriaRAM { get; set; }
        public SituacaoEquipamento SituacaoEquipamento { get; set; }

        //public int CodigoTipoEquipamento { get; set; }
    }
}
