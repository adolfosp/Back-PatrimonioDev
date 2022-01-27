using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entidades
{
    public class Patrimonio
    {
        [Key]
        public int CodigoPatrimonio { get; set; }

        [Required(ErrorMessage = "É necessário informar o modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "É necessário informar a service tag")]
        public string ServiceTag { get; set; }

        public string? Armazenamento { get; set; }
        public string? Processador { get; set; }
        public string? PlacaDeVideo { get; set; }
        public string? MAC { get; set; }
        public string? MemoriaRAM { get; set; }

        [Display(Name = "Situação do equipamento")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public SituacaoEquipamento SituacaoEquipamento { get; set; }

        [Required(ErrorMessage = "É necessário informar o equipamento")]
        public int CodigoTipoEquipamento { get; set; }
        [ForeignKey("CodigoTipoEquipamento")]
        public Equipamento Equipamento { get; set; }

        [Required(ErrorMessage = "É necessário informar o usuário vinculado a este equipamento")]
        public int CodigoUsuario { get; set; }
        [ForeignKey("CodigoUsuario")]
        public Usuario Usuario { get; set; }
    }
}
