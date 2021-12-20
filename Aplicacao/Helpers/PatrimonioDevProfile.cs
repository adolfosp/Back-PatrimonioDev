using AutoMapper;

namespace Aplicacao.Helpers
{
    class PatrimonioDevProfile : Profile
    {
        public PatrimonioDevProfile()
        {
            CreateMap<Domain.Entidades.Empresa, Dtos.EmpresaDto>().ReverseMap();
            CreateMap<Domain.Entidades.InformacaoAdicional, Dtos.InformacaoAdicionalDto>().ReverseMap();

        }
    }
}
