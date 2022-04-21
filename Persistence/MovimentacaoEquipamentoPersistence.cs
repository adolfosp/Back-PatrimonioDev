using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Aplicacao.Interfaces.Persistence;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Helpers;

namespace Persistence
{
    public class MovimentacaoEquipamentoPersistence : IMovimentacaoEquipamentoPersistence
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _queryMovimentacao = "SELECT p.CodigoPatrimonio, me.CodigoMovimentacao, me.DataApropriacao, me.DataDevolucao, me.Observacao, me.MovimentacaoDoEquipamento, u.CodigoUsuario, u.Nome AS NomeUsuario, e.TipoEquipamento, f.NomeFuncionario FROM MovimentacaoEquipamento AS me INNER JOIN Usuario AS u ON u.CodigoUsuario = me.CodigoUsuario INNER JOIN PATRIMONIO AS p ON p.CodigoPatrimonio = me.CodigoPatrimonio INNER JOIN Funcionario AS f ON f.CodigoFuncionario = p.CodigoFuncionario INNER JOIN Equipamento AS e on e.CodigoTipoEquipamento = p.CodigoTipoEquipamento ";

        public MovimentacaoEquipamentoPersistence(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AtualizarMovimentacaoEquipamento(int codigoMovimentacao, MovimentacaoEquipamentoDto movimentacaoEquipamentoDto)
        {
            var movimentacao = await _context.MovimentacaoEquipamento.Where(x => x.CodigoMovimentacao == codigoMovimentacao).Select(x => x).FirstOrDefaultAsync();

            if (movimentacao is null) return 404;

            //REFATORAR: ADICIONAR MAPPER NA APLICACAO
            _mapper.Map(movimentacaoEquipamentoDto, movimentacao);

            await _context.SaveChangesAsync();

            return 200;
        }

        public async Task<MovimentacaoEquipamento> CriarMovimentacaoEquipamento(MovimentacaoEquipamento movimentacaoEquipamento)
        {

            _context.MovimentacaoEquipamento.Add(movimentacaoEquipamento);

            await _context.SaveChangesAsync();

            return movimentacaoEquipamento;
        }

        public async Task<MovimentacaoEquipamentoDto> ObterApenasUmaMovimentacao(int codigoMovimentacao)
        {
            _context.OpenConnection();

            using var command = _context.CreateCommand();

            command.CommandText = $" {_queryMovimentacao} WHERE me.CodigoMovimentacao = {codigoMovimentacao} ";

            using var result = await command.ExecuteReaderAsync();

            return DataReaderMapToList.DataReader<MovimentacaoEquipamentoDto>(result);
        }
        

        public async Task<IEnumerable<MovimentacaoEquipamentoDto>> ObterTodasAsMovimentacoesPorCodigoPatrimonio(int codigoPatrimonio)
        {
            _context.OpenConnection();

            using var command = _context.CreateCommand();

            command.CommandText = $"{_queryMovimentacao} WHERE p.CodigoPatrimonio = {codigoPatrimonio} ";

            using var result = await command.ExecuteReaderAsync();

            return DataReaderMapToList.DataReaderToList<MovimentacaoEquipamentoDto>(result);
        }
    }
}
