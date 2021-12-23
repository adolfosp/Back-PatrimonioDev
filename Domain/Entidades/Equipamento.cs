using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Equipamento
    {
        [Key]
        public int CodigoTipoEquipamento { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string TipoEquipamento { get; set; }

        [ForeignKey("CodigoFabricante")]
        public int CodigoFabricante { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}
