using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class PatrimonioDto
    {
            public string Modelo { get; set; }
            public string ServiceTag { get; set; }
            public string? Armazenamento { get; set; }
            public string? Processador { get; set; }
            public string? PlacaDeVideo { get; set; }
            public string? MAC { get; set; }
            public string? MemoriaRAM { get; set; }
            public SituacaoEquipamento SituacaoEquipamento { get; set; }
            public int CodigoTipoEquipamento { get; set; }
            public int CodigoUsuario { get; set; }
        }
}
