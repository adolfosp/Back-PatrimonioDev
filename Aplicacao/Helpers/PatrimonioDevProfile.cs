using AutoMapper;

namespace Aplicacao.Helpers
{
    public class PatrimonioDevProfile : Profile
    {
        public PatrimonioDevProfile()
        {
            CreateMap<Domain.Entidades.Empresa, Dtos.EmpresaDto>().ReverseMap();
            CreateMap<Domain.Entidades.InformacaoAdicional, Dtos.InformacaoAdicionalDto>().ReverseMap();
            CreateMap<Domain.Entidades.Usuario, Dtos.UsuarioDto>().ReverseMap();
            CreateMap<Domain.Entidades.Equipamento, Dtos.EquipamentoDto>().ReverseMap();
            CreateMap<Domain.Entidades.Patrimonio, Dtos.PatrimonioDto>().ReverseMap();

        }
    }
}
