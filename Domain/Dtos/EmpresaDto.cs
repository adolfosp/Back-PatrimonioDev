namespace Aplicacao.Dtos
{
    public record EmpresaDto
    {
        public string CNPJ { get; init; }
        public string RazaoSocial { get; init; }
        public string NomeFantasia { get; init; }
        public bool EmpresaPadraoImpressao { get; init; }
    }
}
