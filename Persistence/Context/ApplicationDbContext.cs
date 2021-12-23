using Aplicacao.Interfaces;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioPermissao> UsuarioPermissao { get; set; }
        public DbSet<InformacaoAdicional> InformacaoAdicional { get; set; }

        public async Task<int> SaveChangesAsync()
          => await base.SaveChangesAsync();


    }
}
