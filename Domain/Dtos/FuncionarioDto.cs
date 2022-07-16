namespace Aplicacao.Dtos
{
    public record FuncionarioDto
    {
        public string NomeFuncionario { get; init; }
        public bool Ativo { get; init; }
        public string Observacao { get; init; }
    }
}
