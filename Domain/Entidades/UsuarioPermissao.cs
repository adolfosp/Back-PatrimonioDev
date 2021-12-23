using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades
{
    public class UsuarioPermissao
    {
        [Key]
        public int CodigoUsuarioPermissao { get; set; }
        [Required,
            MaxLength(20),
            MinLength(3)]
        public string DescricaoPermissao { get; set; }

        public bool Ativo { get; set; }
    }
}
