using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class Setor
    {
        [Key]
        public int CodigoSetor { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
