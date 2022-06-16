using Aplicacao.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class CategoriaEquipamento
    {
        [Key]
        public int CodigoCategoria { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória"),MinLength(2), MaxLength(50)]
        public string Descricao { get; set; }

        public static implicit operator CategoriaEquipamento(CategoriaDto categoria)
        {
            return new CategoriaEquipamento() { Descricao = categoria.Descricao };
        }

    }
}
