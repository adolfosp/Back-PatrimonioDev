using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class PercaEquipamento
    {
        [Key]
        public int CodigoPerca { get; set; }
        [Required(ErrorMessage = "É necessário informar o motivo da perca"),
         MaxLength(300, ErrorMessage = "O tamanho máximo de caracteres é 300")]
        public string MotivoDaPerca { get; set; }

        [Required]
        public int CodigoPatrimonio { get; set; }
        [ForeignKey("CodigoPatrimonio")]
        public Patrimonio Patrimonio { get; set; }
    }
}
