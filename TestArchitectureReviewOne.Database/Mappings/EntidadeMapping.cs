using Microsoft.EntityFrameworkCore;
using TestArchitectureReviewOne.Domain.Entities;

namespace TestArchitectureReviewOne.Database.Mappings
{
    public class EntidadeMapping : BaseMapping<Entidade>, IMapping
    {

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            entity.Property(a => a.Nome).HasColumnType("varchar(60)").IsRequired();
            entity.HasIndex(a => a.Nome).HasDatabaseName("unq1_entidade").IsUnique();
            entity.Property(a => a.Apelido).HasColumnType("varchar(60)");

            #region Comentários
            entity.HasComment("Tabela reposável por registrar as entidades");
            entity.Property(b => b.Nome).HasComment("Nome da entidade");
            entity.Property(b => b.Apelido).HasComment("Apelido da entidade");
            #endregion
        }

    }
}