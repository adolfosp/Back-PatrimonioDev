using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class PerdaEquipamento
    {
        [Key]
        public int CodigoPerda { get; set; }
        [Required(ErrorMessage = "É necessário informar o motivo da perca"),
         MinLength(30, ErrorMessage = "O tamanho mínimo de caracteres é 30"),
         MaxLength(300, ErrorMessage = "O tamanho máximo de caracteres é 300")]
        public string MotivoDaPerda { get; set; }

        [Required]
        public int CodigoPatrimonio { get; set; }
        [ForeignKey("CodigoPatrimonio")]
        public Patrimonio Patrimonio { get; set; }
    }
}
