namespace Domain.Dtos
{
    public record EstatisticaPatrimonioDisponivelDto
    {
        public int QuantidadePatrimonioDisponivel { get; init; }
        public int QuantidadeTotalPatrimonio { get; init; }
    }
}
