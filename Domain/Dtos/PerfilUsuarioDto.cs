using Domain.Entidades;

namespace Aplicacao.Dtos
{
    public class PerfilUsuarioDto
    {
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string ImagemUrl { get; set; }

        public static implicit operator PerfilUsuarioDto(PerfilUsuario perfil)
        {
            return new PerfilUsuarioDto() {
                CodigoUsuario = perfil.CodigoUsuario,
                NomeUsuario = perfil.NomeUsuario,
                Senha = perfil.Senha,
                ImagemUrl = perfil.ImagemUrl
            };
        }

    }

}
