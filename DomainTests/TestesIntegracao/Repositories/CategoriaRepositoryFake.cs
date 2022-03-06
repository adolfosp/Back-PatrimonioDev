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
                throw new NotImplementedException();
        }
        
        public Task<CategoriaEquipamento> CriarCategoria(CategoriaEquipamento categoria)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletarCategoria(int codigoCategoria)
        {
           return Task.FromResult<int>(1);
        }

        public Task<IEnumerable<CategoriaEquipamento>> ObterTodasCategorias()
        {
            return Task.FromResult<IEnumerable<CategoriaEquipamento>>(null) ;
        }

        public Task<IEnumerable<CategoriaEquipamento>> ObterValorNulo()
        {
            var categoria = new List<CategoriaEquipamento>();
            categoria.Add(new CategoriaEquipamento() { Descricao = "adolfo", CodigoCategoria = 1 });

            return Task.FromResult<IEnumerable<CategoriaEquipamento>>(categoria);
        }
    }
}
