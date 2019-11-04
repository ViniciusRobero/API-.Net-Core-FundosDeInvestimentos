using AtivaInvestimentos.Domain.Entities;
using AtivaInvestimentos.Domain.Entities.Mapeamento;
using AtivaInvestimentos.Infra.DBConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AtivaInvestimentos.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("SqlExpressConnection"));

            }
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        public virtual DbSet<Fundo> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Fundo>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.CNPJFundo)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.InvestimentoMinimo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NomeFundo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasIndex(e => e.Id)
                .IsUnique();

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CPFCliente)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataMovimentacao)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ValorMovimentacao)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.IdFundo)
                  .IsRequired()
                  .IsUnicode(false);

                entity.Property(e => e.IdTipoMovimentacao)
                  .IsRequired()
                  .IsUnicode(false);
            });
        }
    }
}
