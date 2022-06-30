using Aplicacao.Dtos;
using Domain.Entidades;
using Domain.Interfaces.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiTests.TestesIntegracao.Repositories
{
    public class EquipamentoRepositoryFake : IEquipamentoPersistence
    {
        public Task<int> AtualizarEquipamento(int codigoEquipamento, EquipamentoDto equipamento)
        {
            return Task.FromResult(200);
        }

        public Task<Equipamento> CriarEquipamento(EquipamentoDto equipamento)
        {
            return Task.FromResult(new Equipamento());
        }

        public Task<int> DeletarEquipamento(int codigoEquipamento)
        {
            return Task.FromResult(200);
        }

        public Task<Equipamento> ObterEquipamentoPorId(int codigoEquipamento)
        {
            return Task.FromResult(new Equipamento());
        }

        public Task<List<EquipamentoDto>> ObterTodosEquipamentos()
        {
            return Task.FromResult(new List<EquipamentoDto>());
        }
    }
}
