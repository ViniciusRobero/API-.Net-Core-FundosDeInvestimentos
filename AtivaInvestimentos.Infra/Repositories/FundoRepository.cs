using AtivaInvestimentos.Domain.Entities.Mapeamento;
using AtivaInvestimentos.Infra.Context;
using AtivaInvestimentos.Infra.Repositories.Interface;
using AtivaInvestimentos.Infra.Standard;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace AtivaInvestimentos.Infra.Repositories
{
    public class FundoRepository : DomainRepository<Fundo>, IFundoRepository
    {
        private readonly DbSet<Fundo> _fundo;

        public FundoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _fundo = dbContext.Set<Fundo>();
        }

        public List<Fundo> ListarFundos()
        {
            return _fundo.ToList();
        }
    }
}
