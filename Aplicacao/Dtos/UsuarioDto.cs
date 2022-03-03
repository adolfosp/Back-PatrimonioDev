using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplicacao.Dtos
{
    public class UsuarioDto
    {

        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }
        [EmailAddress(ErrorMessage ="É preciso informar um e-mail válido")]
        public string Email { get; set; }
        public string ImagemUrl { get; set; }
        public int? CodigoEmpresa { get; set; }
        public int? CodigoSetor { get; set; }
        public int CodigoUsuarioPermissao { get; set; }
    }
}
