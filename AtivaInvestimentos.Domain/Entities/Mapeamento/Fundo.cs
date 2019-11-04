using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtivaInvestimentos.Domain.Entities.Mapeamento
{
    [Table("Fundo")]
    public class Fundo
    {
        public Guid Id { get; set; }
        public string NomeFundo { get; set; }
        public string CNPJFundo { get; set; }
        public decimal InvestimentoMinimo { get; set; }
    }
}
