using System.Collections.Generic;
using AtivaInvestimentos.Domain.Entities.Mapeamento;

namespace AtivaInvestimentos.Infra.Repositories.Interface
{
    public interface IFundoRepository
    {
        List<Fundo> ListarFundos();
    }
}
