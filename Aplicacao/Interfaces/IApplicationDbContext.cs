using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IApplicationDbContext
    {

        //DbSet<Equipamento> Equipamento { get; set; }

        DbSet<Empresa> Empresa { get; set; }

        DbSet<Setor> Setor { get; set; }
        DbSet<Fabricante> Fabricante { get; set; }


        //DbSet<Usuario> Usuario { get; set; }

        //DbSet<UsuarioPermissao> UsuarioPermissao { get; set; }

        //DbSet<InformacaoAdicional> InformacaoAdicional { get; set; }


        Task<int> SaveChangesAsync();

    }
}
