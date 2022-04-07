using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanSist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanSist.Database.Mappings
{
    public class DespesaMapping : BaseMapping<Despesa>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.entity.Property(a => a.Descricao).HasColumnType("varchar(200)");
            this.entity.Property(a => a.Observacao).HasColumnType("varchar(200)");


            #region  Comments
            this.entity.Property(b => b.DataPagamento).HasComment("Data de pagamento da Despesa.");
            this.entity.Property(b => b.DataPrevisao).HasComment("Data de previsão de pagamento da Despesa.");
            this.entity.Property(b => b.Descricao).HasComment("Descrição da Despesa.");
            this.entity.Property(b => b.CategoriaId).HasComment("Identificador da categoria.");
            this.entity.Property(b => b.EntidadeId).HasComment("Identificador da entidade.");
            this.entity.Property(b => b.TagId).HasComment("Identificador da tag.");
            this.entity.Property(b => b.Observacao).HasComment("Observações da Despesa.");
            #endregion
        }
    }
}