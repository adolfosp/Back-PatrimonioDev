using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Threading.Tasks;

namespace Aplicacao.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Equipamento> Equipamento { get; set; }
        DbSet<Empresa> Empresa { get; set; }
        DbSet<Setor> Setor { get; set; }
        DbSet<Fabricante> Fabricante { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<UsuarioPermissao> UsuarioPermissao { get; set; }
        DbSet<InformacaoAdicional> InformacaoAdicional { get; set; } 
        DbSet<Patrimonio> Patrimonio { get; set; }
        DbSet<PerdaEquipamento> PercaEquipamento { get; set; }
        DbSet<MovimentacaoEquipamento> MovimentacaoEquipamento { get; set; }
        DbSet<CategoriaEquipamento> CategoriaEquipamento { get; set; }
        DbSet<Funcionario> Funcionario { get; set; }

        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransactionAsync();
        void RollbackTransactionAsync();
        public DbCommand CreateCommand();
        public void OpenConnection();
        public void CloseConnection();

    }
}
