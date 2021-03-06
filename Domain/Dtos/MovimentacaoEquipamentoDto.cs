using Domain.Enums;
using System;

namespace Aplicacao.Dtos
{
    public class MovimentacaoEquipamentoDto
    {

        public int CodigoMovimentacao { get; set; }
        public DateTime DataApropriacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Observacao { get; set; }
        public SituacaoMovimentacaoEquipamento MovimentacaoDoEquipamento { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoPatrimonio { get; set; }
        public string NomeUsuario { get; set; }
        public string TipoEquipamento { get; set; }
        public string NomeFuncionario { get; set; }

    }
}
