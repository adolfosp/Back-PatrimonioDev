using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class PercaEquipamentoDto
    {
        [Required(ErrorMessage = "É necessário informar o motivo da perca"),
         MaxLength(300, ErrorMessage = "O tamanho máximo de caracteres é 300")]
        public string MotivoDaPerca { get; set; }

        [Required]
        public int CodigoPatrimonio { get; set; }

    }
}
