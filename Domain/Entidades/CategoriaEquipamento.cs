using Aplicacao.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class CategoriaEquipamento
    {
        [Key]
        public int CodigoCategoria { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(50), Required]
        public string Descricao { get; set; }

        public static implicit operator CategoriaEquipamento(CategoriaDto categoria)
        {
            return new CategoriaEquipamento() { Descricao = categoria.Descricao };
        }

    }
}
