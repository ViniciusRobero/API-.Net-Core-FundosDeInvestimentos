using System;
using System.Collections.Generic;
using System.Text;

namespace AtivaInvestimentos.Infra.Standard
{
    public interface IDomainRepository<TEntity> : IDisposable where TEntity : class
    {}
}
