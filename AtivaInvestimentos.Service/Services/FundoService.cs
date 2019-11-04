
using System;
using System.Collections.Generic;
using System.Linq;
using AtivaInvestimentos.Domain.DTOs;
using AtivaInvestimentos.Domain.Entities.Mapeamento;
using AtivaInvestimentos.Domain.Interfaces;
using AtivaInvestimentos.Infra.Repositories.Interface;

namespace AtivaInvestimentos.Service.Services
{
    public class FundoService : IFundoService
    {
        private readonly IFundoRepository _fundoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public FundoService(IFundoRepository fundoRepository,
            IMovimentacaoRepository movimentacaoRepository)
        {
            _fundoRepository = fundoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public List<Fundo> ListarFundos()
        {
            return _fundoRepository.ListarFundos();
        }

        public bool Aplicar(MovimentacaoRequestDTO dto)
        {
            var movimentacao = new Movimentacao(dto, TipoMovimentacao.Aplicacao);
            return _movimentacaoRepository.CriarMovimentacao(movimentacao);
        }

        public bool Resgatar(MovimentacaoRequestDTO dto)
        {
            ValidarResgate(dto);
            var movimentacao = new Movimentacao(dto, TipoMovimentacao.Resgate);
            return _movimentacaoRepository.CriarMovimentacao(movimentacao);
        }

        private bool ValidarResgate(MovimentacaoRequestDTO dto)
        {
            var movimentacoesCliente = _movimentacaoRepository.ListarMovimentacoesCliente(dto.CPFCliente);
            if (!ClientePossuiDinheiroAplicadoNoFundo(dto, movimentacoesCliente))
                throw new Exception("O Cliente não possui dinheiro investido no fundo selecionado.");

            if (!ClientePossuiDinheiroSuficienteNoFundoSelecionado(dto, movimentacoesCliente))
                throw new Exception("O valor informado para resgate é maior do que o cliente possui investido.");

            return true;
        }

        public static bool ClientePossuiDinheiroAplicadoNoFundo(MovimentacaoRequestDTO dto, List<Movimentacao> movimentacoesCliente)
        {
            return movimentacoesCliente.Any(x => x.IdFundo == Guid.Parse(dto.IdFundo));
        }

        public static bool ClientePossuiDinheiroSuficienteNoFundoSelecionado(MovimentacaoRequestDTO dto, List<Movimentacao> movimentacoesCliente)
        {
            var movimentacoes = movimentacoesCliente.Where(x => x.IdFundo == Guid.Parse(dto.IdFundo));
            var dinheiroDisponivelNoFundo = RetornarValorAplicadoNoFundo(movimentacoes);
            return dinheiroDisponivelNoFundo >= dto.ValorMovimentacao;
        }

        private static decimal RetornarValorAplicadoNoFundo(IEnumerable<Movimentacao> movimentacoes)
        {
            return (movimentacoes.Where(x => x.IdTipoMovimentacao == (int)TipoMovimentacao.Aplicacao).Sum(x => x.ValorMovimentacao))
                - (movimentacoes.Where(x => x.IdTipoMovimentacao == (int)TipoMovimentacao.Resgate).Sum(x => x.ValorMovimentacao));
        }
    }
}

