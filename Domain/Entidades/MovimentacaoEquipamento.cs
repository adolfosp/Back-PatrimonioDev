using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entidades
{
    public class MovimentacaoEquipamento
    {
        [Key]
        public int CodigoMovimentacao { get; set; }

        [Display(Name = "Data de apropriação")]
        [Required(ErrorMessage = "É necessário informar a {0} do equipamento")]
        public DateTime DataApropriacao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "É necessário informar qual movimentação foi realizada")]
        public SituacaoMovimentacaoEquipamento MovimentacaoDoEquipamento { get; set; }

        public int CodigoUsuario { get; set; }
        [ForeignKey("CodigoUsuario")]
        public Usuario Usuario { get; set; }

        public int CodigoPatrimonio { get; set; }
        [ForeignKey("CodigoPatrimonio")]
        public Patrimonio Patrimonio{ get; set; }

    }
}
