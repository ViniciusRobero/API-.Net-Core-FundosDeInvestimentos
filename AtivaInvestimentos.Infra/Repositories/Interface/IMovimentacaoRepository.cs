using AtivaInvestimentos.Domain.Entities.Mapeamento;
using System.Collections.Generic;

namespace AtivaInvestimentos.Infra.Repositories.Interface
{
    public interface IMovimentacaoRepository
    {
        bool CriarMovimentacao(Movimentacao movimentacao);
        List<Movimentacao> ListarMovimentacoesCliente(string cpfCliente);
    }
}
