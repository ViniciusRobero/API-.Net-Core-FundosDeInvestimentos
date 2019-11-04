using System.ComponentModel.DataAnnotations;

namespace AtivaInvestimentos.Domain.DTOs
{
    public class MovimentacaoRequestDTO
    {
        [Required]
        public string IdFundo { get; set; }
        [Required]
        public string CPFCliente { get; set; }
        [Required]
        public decimal ValorMovimentacao { get; set; }
    }
}
