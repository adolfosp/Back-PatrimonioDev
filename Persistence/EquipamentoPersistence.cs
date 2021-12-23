using Aplicacao.Interfaces.Persistence;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public class EquipamentoPersistence : IEquipamentoPersistence
    {
        public Task<Equipamento> CriarEquipamento(Equipamento equipamento)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletarEquipamento(int codigoEquipamento)
        {
            throw new NotImplementedException();
        }

        public Task<Equipamento> ObterEquipamentoPorId()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Equipamento>> ObterTodosEquipamentos()
        {
            throw new NotImplementedException();
        }
    }
}
