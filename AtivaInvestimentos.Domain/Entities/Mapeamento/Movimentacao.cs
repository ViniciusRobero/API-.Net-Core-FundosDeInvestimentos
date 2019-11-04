using AtivaInvestimentos.Domain.DTOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtivaInvestimentos.Domain.Entities.Mapeamento
{
    [Table("Movimentacao")]
    public class Movimentacao
    {
        public Movimentacao() { }

        public Movimentacao(MovimentacaoRequestDTO dto, TipoMovimentacao tipoMovimentacao)
        {
            Id = Guid.NewGuid();
            IdTipoMovimentacao = (int)tipoMovimentacao;
            IdFundo = Guid.Parse(dto.IdFundo);
            CPFCliente = dto.CPFCliente;
            ValorMovimentacao = dto.ValorMovimentacao;
            DataMovimentacao = DateTime.Now;
        }

        public Guid Id { get; set; }
        public int IdTipoMovimentacao { get; set; }
        public Guid IdFundo { get; set; }
        public string CPFCliente { get; set; }
        public decimal ValorMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
