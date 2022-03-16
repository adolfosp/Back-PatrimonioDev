using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainTests.TestesIntegracao.Repositories

{
    internal class CategoriaRepositoryFake : ICategoriaPersistence
    {
        public Task<int> AtualizarEquipamento(int codigoCategoria, CategoriaEquipamento categoria)
        {
            return Task.FromResult<int>(200);
        }

        public Task<CategoriaEquipamento> CriarCategoria(CategoriaEquipamento categoria)
        {
            return Task.FromResult<CategoriaEquipamento>(new CategoriaEquipamento());
        }

        public Task<int> DeletarCategoria(int codigoCategoria)
        {
           return Task.FromResult<int>(200);
        }

        public Task<CategoriaEquipamento> ObterApenasUmaCategoria(int codigoCategoria)
        {
            return Task.FromResult<CategoriaEquipamento>(new CategoriaEquipamento());

        }

        public Task<IEnumerable<CategoriaEquipamento>> ObterTodasCategorias()
        {
            return Task.FromResult<IEnumerable<CategoriaEquipamento>>(new List<CategoriaEquipamento>()) ;
        }
    }
}
