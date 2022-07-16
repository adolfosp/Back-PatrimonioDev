using Domain.Enums;
using System;

namespace Aplicacao.Dtos
{
    public record MovimentacaoEquipamentoDto
    {

        public int CodigoMovimentacao { get; init; }
        public DateTime DataApropriacao { get; init; }
        public DateTime? DataDevolucao { get; init; }
        public string Observacao { get; init; }
        public SituacaoMovimentacaoEquipamento MovimentacaoDoEquipamento { get; init; }
        public int CodigoUsuario { get; init; }
        public int CodigoPatrimonio { get; init; }
        public string NomeUsuario { get; init; }
        public string TipoEquipamento { get; init; }
        public string NomeFuncionario { get; init; }

    }
}
