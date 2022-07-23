using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Equipamento
    {
        [Key]
        public int CodigoTipoEquipamento { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(50), Required]
        public string TipoEquipamento { get; set; }

        public int CodigoFabricante { get; set; }

        [ForeignKey("CodigoFabricante")]
        public Fabricante Fabricante { get; set; }

        public int CodigoCategoria { get; set; }
        [ForeignKey("CodigoCategoria")]
        public CategoriaEquipamento Categoria { get; set; }

    }
}
