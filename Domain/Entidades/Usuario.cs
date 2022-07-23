using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    public class Usuario
    {

        public Usuario()
        {
        }

        public Usuario(int codigoUsuario, bool ativo, string nome, string senha, string email, string imagemUrl, int? codigoEmpresa,int? codigoSetor, int codigoUsuarioPermissao)
        {
            CodigoUsuario = codigoUsuario;
            Ativo = ativo;
            Nome = nome;
            Senha = senha;
            Email = email;
            ImagemUrl = imagemUrl;
            CodigoEmpresa = codigoEmpresa;
            CodigoSetor = codigoSetor;
            CodigoUsuarioPermissao = codigoUsuarioPermissao;
        }

        [Key]
        public int CodigoUsuario { get; set; }

        [Column(TypeName = "BIT")]
        public bool Ativo { get; set; }

        [Required,Column(TypeName = "VARCHAR"), StringLength(50)]
        public string Nome { get; set; }


        [Required,Column(TypeName = "VARCHAR"), StringLength(350)]
        public string Senha { get; set; }

        [NotMapped]
        public string Token { get; set; }

        [Required]
        [MinLength(10)]
        public string Email { get; set; }

        public string ImagemUrl { get; set; }

        public int? CodigoEmpresa { get; set; }
        [ForeignKey("CodigoEmpresa")]
        public Empresa Empresa { get; set; }

        public int? CodigoSetor { get; set; }
        [ForeignKey("CodigoSetor")]
        public Setor Setor { get; set; }

        public int CodigoUsuarioPermissao { get; set; }
        [ForeignKey("CodigoUsuarioPermissao")]
        public UsuarioPermissao UsuarioPermissao { get; set; }


    }
}
