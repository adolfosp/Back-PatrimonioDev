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
            CreateMap<Domain.Entidades.PerdaEquipamento, Dtos.PercaEquipamentoDto>().ReverseMap();
            CreateMap<Domain.Entidades.MovimentacaoEquipamento, Dtos.MovimentacaoEquipamentoDto>().ReverseMap();
            CreateMap<Domain.Entidades.Funcionario, Dtos.FuncionarioDto>().ReverseMap();
            CreateMap<Domain.Entidades.PerfilUsuario, Dtos.PerfilUsuarioDto>().ReverseMap();
            CreateMap<Domain.Entidades.UsuarioPermissao, Dtos.UsuarioPermissaoDto>().ReverseMap();


        }
    }
}
