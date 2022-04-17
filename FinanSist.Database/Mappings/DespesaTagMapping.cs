using FinanSist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanSist.Database.Mappings
{
    public class DespesaTagMapping : BaseMapping<DespesaTag>, IMapping
    {

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Executando classe da base (BaseMapping).

            entity.HasIndex(c => new { c.DespesaId, c.TagId }).HasDatabaseName("unq1_DespesaTag").IsUnique();
            entity.HasOne<Despesa>(d => d.Despesa).WithMany(d => d.DespesaTag).OnDelete(DeleteBehavior.Cascade);



            #region Comments
            entity.HasComment("Tabela responsável por gerir a relação de Depesas e Tags");
            entity.Property(b => b.DespesaId).HasComment("Identificador da despesa");
            entity.Property(b => b.TagId).HasComment("Identificador da tag");
            #endregion
        }
    }
}