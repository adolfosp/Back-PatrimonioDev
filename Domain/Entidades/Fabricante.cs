using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class Fabricante
    {

        [Key]
        public int CodigoFabricante { get; set; }

        [Required]
        [MaxLength(60)]
        public string NomeFabricante { get; set; }
    }
}
