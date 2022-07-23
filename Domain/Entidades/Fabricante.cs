using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Fabricante
    {
        [Key]
        public int CodigoFabricante { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(60), Required]
        public string NomeFabricante { get; set; }
    }
}
