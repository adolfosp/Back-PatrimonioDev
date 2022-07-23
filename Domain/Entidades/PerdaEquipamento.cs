using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class PerdaEquipamento
    {
        [Key]
        public int CodigoPerda { get; set; }

        [Required, Column(TypeName ="VARCHAR"), StringLength(300)]
        public string MotivoDaPerda { get; set; }

        [Required]
        public int CodigoPatrimonio { get; set; }

        [ForeignKey("CodigoPatrimonio")]
        public Patrimonio Patrimonio { get; set; }
    }
}
