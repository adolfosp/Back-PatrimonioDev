namespace Aplicacao.Dtos
{
    public record UsuarioDto
    {
        public string Nome { get; init; }
        public bool Ativo { get; init; }
        public string Senha { get; init; }
        public string Email { get; init; }
        public string ImagemUrl { get; init; }
        public int? CodigoEmpresa { get; init; }
        public int? CodigoSetor { get; init; }
        public int CodigoUsuarioPermissao { get; init; }
    }
}
