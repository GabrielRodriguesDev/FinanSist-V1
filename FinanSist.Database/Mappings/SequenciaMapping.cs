using FinanSist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanSist.Database.Mappings
{
    public class SequenciaMapping : BaseMapping<Sequencia>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            entity.Property(a => a.Numero).HasColumnType("int").IsRequired();
            entity.Property(a => a.Nome).HasColumnType("varchar(100)").IsRequired();
            entity.HasIndex(a => a.Nome).HasDatabaseName("UnqSequenciaNome").IsUnique();


            #region Comments
            entity.HasComment("Tabela responsável pelo controle de contadores (sequência)");
            entity.Property(b => b.Numero).HasComment("Número da sequência");
            entity.Property(b => b.Nome).HasComment("Nome da sequência");
            #endregion
        }
    }
}