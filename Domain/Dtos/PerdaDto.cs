namespace Domain.Dtos
{
    public record PerdaDto
    {
        public int CodigoPerda { get; init; }
        public string TipoEquipamento { get; init; }
        public string MotivoDaPerda { get; init; }
        public string NomeFuncionario { get; init; }
        public string NomeUsuario { get; init; }
    }
}
