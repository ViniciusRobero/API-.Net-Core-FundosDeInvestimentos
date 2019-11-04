using AtivaInvestimentos.Domain.Entities.Mapeamento;
using AtivaInvestimentos.Infra.Context;
using AtivaInvestimentos.Infra.Repositories.Interface;
using AtivaInvestimentos.Infra.Standard;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AtivaInvestimentos.Infra.Repositories
{
    public class MovimentacaoRepository : DomainRepository<Movimentacao>, IMovimentacaoRepository
    {
        private readonly DbSet<Movimentacao> _movimentacao;

        public MovimentacaoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _movimentacao = dbContext.Set<Movimentacao>();
        }

        public bool CriarMovimentacao(Movimentacao movimentacao)
        {
            try
            {
                _movimentacao.Add(movimentacao);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Movimentacao> ListarMovimentacoesCliente(string cpfCliente)
        {
            return _movimentacao.Where(x => x.CPFCliente == cpfCliente).ToList();
        }
    }
}
