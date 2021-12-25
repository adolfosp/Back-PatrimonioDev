using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class PatrimonioDto
    {
       
        [MaxLength(70, ErrorMessage = "O valor máximo de caracter é 70")]
        public string? Modelo { get; set; }

        [MaxLength(50, ErrorMessage = "O valor máximo de caracter é 50")]
        public string? ServiceTag { get; set; }

        [MaxLength(50, ErrorMessage = "O valor máximo de caracter é 50")]
        public string? Armazenamento { get; set; }

        [MaxLength(50, ErrorMessage = "O valor máximo de caracter é 50")]
        public string? Processador { get; set; }

        [MaxLength(50, ErrorMessage = "O valor máximo de caracter é 50")]
        public string? PlacaDeVideo { get; set; }

        [MaxLength(70, ErrorMessage = "O valor máximo de caracter é 70")]
        public string? MAC { get; set; }
        public string? MemoriaRAM { get; set; }

        [Display(Name = "Situação do equipamento")]
        [Required(ErrorMessage = "É necessário informar a {0}")]
        public SituacaoEquipamento SituacaoEquipamento { get; set; }

        [Required(ErrorMessage = "É necessário informar o equipamento")]
        public int CodigoTipoEquipamento { get; set; }

        [Required(ErrorMessage = "É necessário informar as informações adicionais")]
        public int CodigoInformacao { get; set; }

        [Required(ErrorMessage = "É necessário informar o usuário vinculado a este equipamento")]
        public int CodigoUsuario { get; set; }
    
    }
}
