using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class CategoriaEquipamento
    {
        [Key]
        public int CodigoCategoria { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória"),MinLength(5), MaxLength(50)]
        public string Descricao { get; set; }
    }
}
