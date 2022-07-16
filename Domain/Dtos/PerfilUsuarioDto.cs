using Domain.Entidades;

namespace Aplicacao.Dtos
{
    public record PerfilUsuarioDto
    {
        public int CodigoUsuario { get; init; }
        public string NomeUsuario { get; init; }
        public string Senha { get; init; }
        public string ImagemUrl { get; init; }

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
