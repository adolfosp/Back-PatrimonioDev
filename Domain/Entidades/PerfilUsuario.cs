using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [NotMapped]
    public class PerfilUsuario
    {
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeSetor { get; set; }
        public string RazaoSocial { get; set; }
        public string DescricaoPermissao { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ImagemUrl { get; set; }

    }
}
