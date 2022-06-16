using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class PerdaEquipamentoDto
    {
        [Required(ErrorMessage = "É necessário informar o motivo da perca"),
         MaxLength(300, ErrorMessage = "O tamanho máximo de caracteres é 300")]
        public string MotivoDaPerda { get; set; }

        [Required]
        public int CodigoPatrimonio { get; set; }

    }
}
