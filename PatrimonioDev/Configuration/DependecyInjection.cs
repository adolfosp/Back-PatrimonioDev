
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using Domain.Interfaces.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Context;
using Persistence.Contexts;

namespace PatrimonioDev
{
    public static class DependecyInjection
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped<IUsuarioPermissaoPersistence, UsuarioPermissaoPersistence>();
            services.AddScoped<IUsuarioPersistence, UsuarioPersistence>();
            services.AddScoped<IEquipamentoPersistence, EquipamentoPersistence>();
            services.AddScoped<IPatrimonioPersistence, PatrimonioPersistence>();
            services.AddScoped<IPerdaEquipamentoPersistence, PerdaEquipamentoPersistence>();
            services.AddScoped<IMovimentacaoEquipamentoPersistence, MovimentacaoEquipamentoPersistence>();
            services.AddScoped<ICategoriaPersistence, CategoriaPersistence>();
            services.AddScoped<IFuncionarioPersistence, FuncionarioPersistence>();
            services.AddScoped<IPerfilUsuarioPersistence, PerfilUsuarioPersistence>();
            services.AddScoped<IEstatisticaPersistence, EstatisticaPersistence>();
            services.AddScoped<IRelatorio, RelatorioPersistence>();
            services.AddScoped<IEmpresaPersistence, EmpresaPersistence>();
            services.AddScoped<IFabricantePersistence, FabricantePersistence>();

            services.AddSingleton<DapperContext>();


        }
    }
}
