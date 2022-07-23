using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class UsuarioPermissao
    {
        public UsuarioPermissao()
        {
        }

        public UsuarioPermissao(int codigoUsuarioPermissao, string descricaoPermissao, bool ativo)
        {
            CodigoUsuarioPermissao = codigoUsuarioPermissao;
            DescricaoPermissao = descricaoPermissao;
            Ativo = ativo;
        }

        [Key]
        public int CodigoUsuarioPermissao { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(20)]
        public string DescricaoPermissao { get; set; }

        public bool Ativo { get; set; }
    }
}
