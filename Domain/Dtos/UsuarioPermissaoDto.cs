namespace Aplicacao.Dtos
{
    public record UsuarioPermissaoDto
    {
        public string DescricaoPermissao { get; init; }
        public bool Ativo { get; init; }
    }
}
