using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class MovimentacaoEquipamento
    {
        [Key]
        public int CodigoMovimentacao { get; set; }

        [Display(Name = "Data de apropriação")]
        [Required(ErrorMessage = "É necessário informar a {0} do equipamento")]
        public DateTime DataApropriacao { get; set; }
        public DateTime? DataEvolucao { get; set; }
        public string? Observacao { get; set; }

        [ForeignKey("CodigoUsuario")]
        public int CodigoUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("CodigoPatrimonio")]
        public int CodigoPatrimonio { get; set; }
        public Patrimonio Patrimonio{ get; set; }

    }
}
