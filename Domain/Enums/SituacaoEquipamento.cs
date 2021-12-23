using System.ComponentModel;

namespace Domain.Enums
{
    public enum SituacaoEquipamento
    {
        [Description("EM USO")]
        EMUSO = 1,

        [Description("DISPONÍVEL")]
        DISPONIVEL = 2,

        [Description("DANIFICADO")]
        DANIFICADO = 3,

        [Description("MANUTENCAO")]
        MANUTENCAO = 4,
    }
}
