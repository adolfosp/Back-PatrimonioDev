using System.ComponentModel;

namespace Domain.Enums
{
    public enum SituacaoMovimentacaoEquipamento
    {
        [Description("ENTREGUE")]
        ENTREGUE = 1,

        [Description("EM USO")]
        EMUSO = 2
    }
}
