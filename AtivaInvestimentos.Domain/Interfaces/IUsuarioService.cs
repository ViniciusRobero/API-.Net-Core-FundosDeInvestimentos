using AtivaInvestimentos.Domain.DTOs;
using AtivaInvestimentos.Domain.Entities.Mapeamento;
using System.Collections.Generic;

namespace AtivaInvestimentos.Domain.Interfaces
{
    public interface IFundoService
    {
        List<Fundo> ListarFundos();
        bool Aplicar(MovimentacaoRequestDTO movimentacao);
        bool Resgatar(MovimentacaoRequestDTO movimentacao);
    }
}
