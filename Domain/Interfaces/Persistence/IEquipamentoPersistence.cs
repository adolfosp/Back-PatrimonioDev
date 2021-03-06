using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Dtos;

namespace Domain.Interfaces.Persistence
{
    public interface IEquipamentoPersistence
    {
        Task<int> DeletarEquipamento(int codigoEquipamento);
        Task<Equipamento> CriarEquipamento(EquipamentoDto equipamento);
        Task<List<EquipamentoDto>> ObterTodosEquipamentos();
        Task<Equipamento> ObterEquipamentoPorId(int codigoEquipamento);
        Task<int> AtualizarEquipamento(int codigoEquipamento, EquipamentoDto equipamento);


    }
}
