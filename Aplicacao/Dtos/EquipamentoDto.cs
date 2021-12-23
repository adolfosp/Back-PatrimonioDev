
using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class EquipamentoDto
    {
        [Required(ErrorMessage = "A descrição do equipamento precisa ser preenchida.")]

        [MaxLength(20, ErrorMessage = "É necessário informar no máximo 20 caracteres")]
        public string TipoEquipamento { get; set; }

        [Required(ErrorMessage = "É necessário informar o fabricante.")]
        public int CodigoFabricante { get; set; }
    }
}
