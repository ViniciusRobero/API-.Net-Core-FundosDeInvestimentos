using AtivaInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtivaInvestimentos.Infra.Standard
{
    public class DomainRepository<TEntity> : IDomainRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext dbContext;
 
        protected DomainRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
